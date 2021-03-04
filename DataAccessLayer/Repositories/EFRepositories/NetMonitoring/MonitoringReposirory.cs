using DataAccessLayer.AppContext;
using DataAccessLayer.Entities.NetMonitoring;
using DataAccessLayer.Repositories.Interfaces.NetMonitoring;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.EFRepositories.NetMonitoring
{
    public class MonitoringReposirory : IMonitoringRepository
    {
        private readonly NetMonitoringContext _netMonitoringContext;
        public MonitoringReposirory (NetMonitoringContext netMonitoringContext)
        {
            _netMonitoringContext = netMonitoringContext;
        }

        public async Task<int> getCountStock()
        {
            Monitoring lastStock = await _netMonitoringContext.Monitorings.Where(x => x.LogTime.Value.Date == DateTime.Today.Date).Where(x => x.Device == "router").OrderByDescending(x => x.Stock).FirstAsync();

            int? nStock = lastStock.Stock;

            int count = nStock.GetValueOrDefault();

            return count;
        }

        public async Task<List<int?>> getGreenFrom5Day()
        {
            List<int?> greenFrom5Day = await _netMonitoringContext.Monitorings.Where(x => x.LogTime.Value.Date >= DateTime.Today.Date.AddDays(-5)).Where(x => x.Device == "router").Where(x => x.Status == 1).Select(x => x.Stock).Distinct().OrderBy(x => x.Value).ToListAsync();

            return greenFrom5Day;
        }

        public async Task<List<Monitoring>> getStockR(int count)
        {

            List<Monitoring> monitorings = await _netMonitoringContext.Monitorings.Where(x => x.LogTime.Value.Date == DateTime.Today.Date).Where(x => x.Device == "router").OrderByDescending(x => x.LogTime).Take(count).OrderBy(x=>x.Stock).ToListAsync();

            return monitorings;
        }

        public async Task<List<Monitoring>> getStockS(int count)
        {

            List<Monitoring> monitorings = await _netMonitoringContext.Monitorings.Where(x => x.LogTime.Value.Date == DateTime.Today.Date).Where(x => x.Device == "S").OrderByDescending(x => x.LogTime).Take(count).OrderBy(x => x.Stock).ToListAsync();

            return monitorings;
        }

    }
}