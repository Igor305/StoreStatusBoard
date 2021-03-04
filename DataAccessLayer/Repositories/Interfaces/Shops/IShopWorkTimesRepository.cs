using DataAccessLayer.Entities.Shops;
using System;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces.Shops
{
    public interface IShopWorkTimesRepository
    {
        public Task<DateTime> getShopWorkTimesFrom(int nstock);
        public Task<DateTime> getShopWorkTimesTo(int nstock);
    }
}
