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

        public async Task<List<int?>> GetGreenFrom5Day()
        {
            List<int?> greenFrom5Day = await _netMonitoringContext.Monitorings.Where(x => x.LogTime.Value.Date >= DateTime.Today.Date.AddDays(-5)).Where(x => x.Device == "router").Where(x => x.Status == 1).Select(x => x.Stock).Distinct().OrderBy(x => x.Value).ToListAsync();

            return greenFrom5Day;
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