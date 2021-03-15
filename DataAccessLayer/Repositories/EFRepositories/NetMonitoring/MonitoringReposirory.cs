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


       /* public static IEnumerable<Monitoring> getStartStocksR(int? nstock)
        {
            Monitoring monitoring = monitorings.Where(x => x.Stock == nstock).FirstOrDefault();
            if (monitoring != null)
            {
                var df = getStartStocksR(monitorings, monitoring.Stock);
                var resultAsE = new[] { monitoring };
                if (!monitoring.Stock.HasValue)
                    return resultAsE;
                else
                    return getStartStocksR(monitorings, monitoring.Stock);
            }

            return new Monitoring[] { };
        }

        public async Task<Monitoring> getStartStocksS(int nstock)
        {

            Monitoring monitoring = await _netMonitoringContext.Monitorings.Where(x => x.LogTime.Value.Date == DateTime.Today.Date).Where(x => x.Device == "S").Where(x => x.Stock == nstock).OrderByDescending(x => x.LogTime).FirstOrDefaultAsync();

            return monitoring;
        }*/

        public async Task<List<Monitoring>> getStocksR(int count)
        {

            List<Monitoring> monitorings = await _netMonitoringContext.Monitorings.Where(x => x.LogTime.Value.Date == DateTime.Today.Date && x.Device == "router").OrderByDescending(x => x.LogTime).Take(count).OrderBy(x=>x.Stock).ToListAsync();

            return monitorings;
        }

        public async Task<List<Monitoring>> getStocksS(int count)
        {

            List<Monitoring> monitorings = await _netMonitoringContext.Monitorings.Where(x => x.LogTime.Value.Date == DateTime.Today.Date && x.Device == "S").OrderByDescending(x => x.LogTime).Take(count).OrderBy(x => x.Stock).ToListAsync();

            return monitorings;
        }

        public async Task<List<string>> getDevicesFromStock(int nstock)
        {

            List<string> devices = await _netMonitoringContext.Monitorings.Where(x => x.LogTime.Value.Date == DateTime.Today.Date && x.Stock == nstock).Select(x => x.Device).Distinct().OrderBy(x => x).ToListAsync();

            return devices;
        }

        public async Task<Monitoring> getDeviceFromLastLogTime(int nstock, string device)
        {

            Monitoring monitorings = await _netMonitoringContext.Monitorings.Where(x => x.Stock == nstock && x.Device == device).OrderByDescending(x => x.LogTime).FirstAsync();

            return monitorings;
        }

        public async Task<List<Monitoring>> getStatusStockHours(int nstock, int hour)
        {
            List<Monitoring> monitorings = await _netMonitoringContext.Monitorings.Where(x => x.LogTime.Value.Date == DateTime.Today.Date &&
                x.LogTime.Value.Hour == hour-1 && x.LogTime.Value.Hour < hour && x.LogTime.Value.Minute > 29 &&
                x.Stock == nstock && (x.Device == "router" || x.Device == "S")).ToListAsync();

            return monitorings;
        }

        public async Task<List<Monitoring>> getStatusStock30Minutes(int nstock, int hour)
        {
            List<Monitoring> monitorings = await _netMonitoringContext.Monitorings.Where(x => x.LogTime.Value.Date == DateTime.Today.Date &&
                x.LogTime.Value.Hour == hour && x.LogTime.Value.Hour < hour+1 && x.LogTime.Value.Minute >= 0 && x.LogTime.Value.Minute < 30 &&
                x.Stock == nstock && (x.Device == "router" || x.Device == "S")).ToListAsync();

            return monitorings;
        }
    }
}