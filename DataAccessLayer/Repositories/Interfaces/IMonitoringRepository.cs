﻿using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IMonitoringRepository
    {
        public Task<int> GetCountStock();
        public Task<List<Monitoring>> GetAllAsync(int count);
    }
}
