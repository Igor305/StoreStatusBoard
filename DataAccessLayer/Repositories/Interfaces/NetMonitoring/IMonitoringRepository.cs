using DataAccessLayer.Entities.NetMonitoring;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces.NetMonitoring
{
    public interface IMonitoringRepository
    {
        public Task<int> getCountStock();
        public Task<List<int?>> getGreenFrom5Day();
        public Task<List<Monitoring>> getStocksR(int nstock);
        public Task<List<Monitoring>> getStocksS(int nstock);
        public Task<List<string>> getDevicesFromStock(int nstock);
        public Task<Monitoring> getDeviceFromLastLogTime(int nstock, string device);
        public Task<List<Monitoring>> getStatusStockFromHours(int nstock, int hour);
        public Task<List<Monitoring>> getStatusStockFrom30Minutes(int nstock, int hour);

    }
}
