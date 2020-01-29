using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TvMaze.Core.Persistence.Contexts;
using TvMaze.Core.Persistence.Repositories;

namespace TvMaze.Scraper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddDbContext<AppDbContext>(options => {
                        options.UseInMemoryDatabase("shows-api-in-memory");
                    });
                    services.AddScoped<IShowRespository, ShowRepository>();
                    services.AddScoped<ImportRunRepository, ImportRunRepository>();
                    services.AddScoped<ICastMemberRepository, CastMemberRepository>();

                });
    }
}
