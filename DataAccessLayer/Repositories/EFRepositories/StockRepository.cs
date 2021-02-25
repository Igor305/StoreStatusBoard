using DataAccessLayer.AppContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.EFRepositories
{
    public class StockRepository : GenericRepository<Stock>, IStockRepository
    {
        public StockRepository (NetMonitoringContext netMonitoringContext) : base (netMonitoringContext)
        {

        }
        public async Task<List<Stock>> GetAllAsync()
        {
            List<Stock> stocks = await _netMonitoringContext.Stocks.ToListAsync();

            return stocks;
        }
    }
}
