using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TvMaze.Domain.Models;

namespace TvMaze.Core.Persistence.Repositories
{
    interface IImportRunRepository
    {
        Task<IEnumerable<ImportRun>> ListAsync();
        Task AddAsync(ImportRun importRun);

    }
}
