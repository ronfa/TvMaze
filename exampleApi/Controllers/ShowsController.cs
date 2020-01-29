using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TvMaze.Domain.Resources;
using TvMaze.Services;
using TvMaze.Domain.Mapping;
using System.Linq;
using TvMaze.Domain.Models;

namespace Supermarket.API.Controllers
{
    [Route("/api/[controller]")]
    public class ShowsController : Controller
    {
        private readonly IShowService _showService;
        
        public ShowsController(IShowService showService)
        {
            _showService = showService;   
        }

        [HttpGet]
        public async Task<IEnumerable<ShowResource>> GetAllAsync([FromQuery] PagingParameters pagingParameters)
        {
            var shows = await _showService.ListAsync(pagingParameters);
            var resources = shows.Select(ShowMapper.ToShowResource).ToList();
            
            return resources;            
        }

      
    }
}


