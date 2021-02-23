using DataAccessLayer.AppContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.EFRepositories
{
    public class StocksRepository : GenericRepository<Stocks>, IStocksRepository
    {
        public StocksRepository (ApplicationContext applicationContext) : base(applicationContext)
        {

        }

        public async Task<List<Stocks>> GetAllAsync()
        {
            List<Stocks> stocks = await _applicationContext.Stocks.ToListAsync();

            return stocks;
        }
    }
}
