using DataAccessLayer.AppContext;
using DataAccessLayer.Repositories.Interfaces.NetMonitoring;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.EFRepositories.NetMonitoring
{
    public class RStockRepository : IRStockRepository
    {
        private readonly NetMonitoringContext _netMonitoringContext;
        public RStockRepository(NetMonitoringContext netMonitoringContext) 
        {
            _netMonitoringContext = netMonitoringContext;
        }

        public async Task<int> getAmountShop()
        {
            int nstock = await _netMonitoringContext.RStocks.Select(x=>x.StockId).OrderByDescending(x=>x).FirstAsync();

            return nstock;
        }
    }
}
