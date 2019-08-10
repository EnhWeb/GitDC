﻿using Ding.Domains.Repositories;
using GitDC.Domain.Models;

namespace GitDC.Domain.Repositories {
    /// <summary>
    /// 仓储
    /// </summary>
    public interface IRepositoriesRepository : IRepository<Repositories,long> {
    }
}