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

        public async Task<int> GetCountStock()
        {
            Monitoring lastStock = await _netMonitoringContext.Monitorings.Where(x => x.LogTime.Value.Date == DateTime.Today.Date).Where(x => x.Device == "router").OrderBy(x => x.Stock).LastAsync();

            int? nStock = lastStock.Stock;

            int count = nStock.GetValueOrDefault();

            return count;
        }

        public async Task<List<Monitoring>> GetStockR(int count)
        {

            List<Monitoring> monitorings = await _netMonitoringContext.Monitorings.Where(x => x.LogTime.Value.Date == DateTime.Today.Date).Where(x => x.Device == "router").OrderByDescending(x => x.LogTime).Take(count).OrderBy(x=>x.Stock).ToListAsync();

            return monitorings;
        }

        public async Task<List<Monitoring>> GetStockS(int count)
        {

            List<Monitoring> monitorings = await _netMonitoringContext.Monitorings.Where(x => x.LogTime.Value.Date == DateTime.Today.Date).Where(x => x.Device == "S").OrderByDescending(x => x.LogTime).Take(count).OrderBy(x => x.Stock).ToListAsync();

            return monitorings;
        }
    }
}