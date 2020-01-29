using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TvMaze.Core.Persistence.Contexts;
using TvMaze.Domain.Models;

namespace TvMaze.Core.Persistence.Repositories
{
    public class CastMemberRepository : BaseRepository, ICastMemberRepository
    {
        public CastMemberRepository(AppDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<CastMember>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(CastMember castMember)
        {
            throw new NotImplementedException();
        }
    }
}
