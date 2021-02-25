using DataAccessLayer.AppContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.EFRepositories
{
    public class MonitoringReposirory : GenericRepository<Monitoring>, IMonitoringRepository
    {
        public MonitoringReposirory (NetMonitoringContext netMonitoringContext) : base(netMonitoringContext)
        {

        }

        public async Task<List<Monitoring>> GetAllAsync()
        {
            List<Monitoring> monitorings = await _netMonitoringContext.Monitorings.Where(x => x.LogTime.Value.Date == DateTime.Today.Date).Where(x => x.Device == "router").ToListAsync();

            return monitorings;
        }
    }
}