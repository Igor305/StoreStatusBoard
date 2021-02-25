using DataAccessLayer.AppContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.EFRepositories
{
    public class RStockRepository : GenericRepository<RStock>, IRStockRepository
    {
        public RStockRepository(NetMonitoringContext netMonitoringContext) : base(netMonitoringContext)
        {

        }

        public async Task<List<RStock>> GetAllAsync()
        {
            List<RStock> rstocks = await _netMonitoringContext.RStocks.ToListAsync();

            return rstocks;
        }
    }
}
