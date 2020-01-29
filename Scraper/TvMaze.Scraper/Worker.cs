using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TvMaze.Core.Persistence.Repositories;
using TvMaze.Domain.Models;

namespace TvMaze.Scraper
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ImportRunRepository _importRunRepository;
        private readonly IShowRespository _showRepository;
        private readonly ICastMemberRepository _castMemberRepository;

        public Worker(ILogger<Worker> logger, ImportRunRepository importRunRepository, IShowRespository showRespository, ICastMemberRepository castMemberRepository)
        {
            _logger = logger;
            _importRunRepository = importRunRepository;
            _showRepository = showRespository;
            _castMemberRepository = castMemberRepository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                var nextPageNumber = await GetLastPageNumber();
                
                var run = new ImportRun { 
                    StartTime = DateTime.UtcNow, 
                    StartPageNum = nextPageNumber, 
                    EndPageNum = nextPageNumber+1 };

                await _importRunRepository.AddAsync(run);

                var shows = new List<Show>();

                var keepGoing = true;
                
                using (var httpClient = new HttpClient())
                {

                    while (keepGoing)
                    {

                        // Wait for 200 ms to not flood the api
                        await Task.Delay(200, stoppingToken);

                        // Call the next page of shows on tvMaze
                        using (var response = await httpClient.GetAsync($"http://api.tvmaze.com/shows?page={run.EndPageNum}"))
                        {
                            if (!response.IsSuccessStatusCode)
                            {
                                // reached the last page
                                keepGoing = false;
                                run.EndPageNum--;
                                break;
                            }

                            string apiResponse = await response.Content.ReadAsStringAsync();
                            shows = JsonConvert.DeserializeObject<List<Show>>(apiResponse);

                            foreach (var show in shows)
                            {
                                // Save show
                                await _showRepository.AddAsync(show);

                                var castMembers = new List<CastMember>();

                                // Wait for 200 ms to not flood the api
                                await Task.Delay(200, stoppingToken);

                                using (var castResponse = await httpClient.GetAsync($"http://api.tvmaze.com/shows/{show.Id}/cast"))
                                {
                                    string apiCastResponse = await castResponse.Content.ReadAsStringAsync();
                                    castMembers = JsonConvert.DeserializeObject<List<CastMember>>(apiCastResponse);

                                    foreach (var member in castMembers)
                                    {
                                        await _castMemberRepository.AddAsync(member);
                                    }
                                }
                            }
                        }
                    }
                }

            

                await Task.Delay(1000, stoppingToken);
            }
        }

        private async Task<int> GetLastPageNumber()
        {
            var runs = await _importRunRepository.ListAsync();

            var lastRun = runs.OrderByDescending(r => r.StartTime).FirstOrDefault();

            if (lastRun == null)
            {
                return 0;
            }

            return lastRun.EndPageNum;
        }
    }
}
