using DataAccessLayer.Entities.NetMonitoring;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces.NetMonitoring
{
    public interface IMonitoringRepository
    {
        public Task<int> getCountStock();
        public Task<List<int?>> getGreenFrom5Day();
        public Task<Monitoring> getStartStocksR(int? nstock);
        public Task<Monitoring> getStartStocksS(int? nstock);
        public Task<Monitoring> getStartGreenFrom5Day(int? nstock);
        public Task<List<Monitoring>> getStocksR(int nstock);
        public Task<List<Monitoring>> getStocksS(int nstock);
        public Task<List<string>> getDevicesFromStock(int nstock);
        public Task<Monitoring> getDeviceFromLastLogTime(int nstock, string device);
        public Task<List<Monitoring>> getStatusStockHours(int nstock, int hour);
        public Task<List<Monitoring>> getStatusStock30Minutes(int nstock, int hour);

    }
}
