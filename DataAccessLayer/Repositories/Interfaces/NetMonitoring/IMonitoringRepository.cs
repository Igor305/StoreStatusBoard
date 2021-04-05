using DataAccessLayer.Entities.NetMonitoring;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces.NetMonitoring
{
    public interface IMonitoringRepository
    {
        public Task<int> getCountStock();
        public Task<List<Monitoring>> getStocksFor5Day();
        public Task<List<int?>> getGreenFrom5Day();
        public Task<List<string>> getDevicesFromStock(int nstock);
        public Task<Monitoring> getDeviceFromLastLogTime(int nstock, string device);
        public Task<List<Monitoring>> getStatusStockHours(int nstock, int hour);
        public Task<List<Monitoring>> getStatusStock30Minutes(int nstock, int hour);

    }
}
