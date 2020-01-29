using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TvMaze.Core.Persistence.Contexts;
using TvMaze.Domain.Models;

namespace TvMaze.Core.Persistence.Repositories
{
    public class ShowRepository : BaseRepository, IShowRespository
    {
        public ShowRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Show>> ListAsync(PagingParameters pagingParameters)
        {
            return await _context.Shows
                .AsNoTracking()
                .Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize)
                .Take(pagingParameters.PageSize)
                .Include(m => m.CastMembers)
                .ToListAsync();
        }

        public Task AddAsync(Show show)
        {
            throw new System.NotImplementedException();
        }
    }
}