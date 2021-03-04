using DataAccessLayer.AppContext;
using DataAccessLayer.Entities.NetMonitoring;
using DataAccessLayer.Repositories.Interfaces.NetMonitoring;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<List<RStock>> getAllAsync()
        {
            List<RStock> rstocks = await _netMonitoringContext.RStocks.ToListAsync();

            return rstocks;
        }
    }
}
