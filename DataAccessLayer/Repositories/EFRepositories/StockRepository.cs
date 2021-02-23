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
        public StockRepository (ApplicationContext applicationContext) : base (applicationContext)
        {

        }
        public async Task<List<Stock>> GetAllAsync()
        {
            List<Stock> stocks = await _applicationContext.Stock.ToListAsync();

            return stocks;
        }
    }
}
