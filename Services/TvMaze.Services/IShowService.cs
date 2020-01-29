using System.Collections.Generic;
using System.Threading.Tasks;
using TvMaze.Domain.Models;

namespace TvMaze.Services
{
    public interface IShowService
    {
        Task<IEnumerable<Show>> ListAsync(PagingParameters pagingParameters);
    }
}