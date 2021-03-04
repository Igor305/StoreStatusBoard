using DataAccessLayer.AppContext;
using DataAccessLayer.Entities.Shops;
using DataAccessLayer.Repositories.Interfaces.Shops;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.EFRepositories.Shops
{
    public class ShopWorkTimesRepository : IShopWorkTimesRepository
    {
        private readonly ShopsContext _shopsContext;
        public ShopWorkTimesRepository (ShopsContext shopsContext) 
        {
            _shopsContext = shopsContext;
        }

        public async Task<DateTime> getShopWorkTimesFrom(int nstock)
        {
            DateTime shopWorkTimesFrom = await _shopsContext.ShopWorkTimes.Where(x => x.Id == nstock).Select(x=>x.TuesdayFrom).FirstAsync();

            return shopWorkTimesFrom;
        }
        public async Task<DateTime> getShopWorkTimesTo(int nstock)
        {
            DateTime shopWorkTimesTo = await _shopsContext.ShopWorkTimes.Where(x => x.Id == nstock).Select(x => x.TuesdayTo).FirstAsync();

            return shopWorkTimesTo;
        }
    }
}
