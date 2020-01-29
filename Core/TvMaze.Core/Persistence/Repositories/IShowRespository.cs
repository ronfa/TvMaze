using System.Collections.Generic;
using System.Threading.Tasks;
using TvMaze.Domain.Models;

namespace TvMaze.Core.Persistence.Repositories
{
    public interface IShowRespository
    {
        Task<IEnumerable<Show>> ListAsync(PagingParameters pagingParameters);
        Task AddAsync(Show show);

    }
}