﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TvMaze.Domain.Models;

namespace TvMaze.Core.Persistence.Repositories
{
    public interface ICastMemberRepository
    {
        Task<IEnumerable<CastMember>> ListAsync();
        Task AddAsync(CastMember importRun);

    }
}
