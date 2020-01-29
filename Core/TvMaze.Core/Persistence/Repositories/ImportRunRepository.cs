using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TvMaze.Core.Persistence.Contexts;
using TvMaze.Domain.Models;

namespace TvMaze.Core.Persistence.Repositories
{
    public class ImportRunRepository : BaseRepository, IImportRunRepository
    {
        public ImportRunRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ImportRun>> ListAsync()
        {
            return await _context.ImportRuns
                .AsNoTracking()
                .ToListAsync();
        }

        public Task AddAsync(ImportRun importRun)
        {
            throw new NotImplementedException();
        }
    }
}
