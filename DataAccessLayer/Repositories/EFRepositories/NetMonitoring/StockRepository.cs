using DataAccessLayer.AppContext;
using DataAccessLayer.Entities.NetMonitoring;
using DataAccessLayer.Repositories.Interfaces.NetMonitoring;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.EFRepositories.NetMonitoring
{
    public class StockRepository : IStockRepository
    {
        private readonly NetMonitoringContext _netMonitoringContext;
        public StockRepository (NetMonitoringContext netMonitoringContext)
        {
            _netMonitoringContext = netMonitoringContext;
        }
        public async Task<List<Stock>> getAllAsync()
        {
            List<Stock> stocks = await _netMonitoringContext.Stocks.ToListAsync();

            return stocks;
        }
    }
}
