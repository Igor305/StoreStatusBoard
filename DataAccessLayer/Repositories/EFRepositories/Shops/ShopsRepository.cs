using DataAccessLayer.AppContext;
using DataAccessLayer.Entities.Shops;
using DataAccessLayer.Repositories.Interfaces.Shops;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.EFRepositories.Shops
{
    public class ShopsRepository : IShopsRepository
    {
        private readonly ShopsContext _shopsContext;

        public ShopsRepository(ShopsContext shopsContext)
        {
            _shopsContext = shopsContext;
        }
        
        public async Task<Shop> getShop(int nshop)
        {
            Shop shop = await _shopsContext.Shops.Where(x => x.ShopNumber == nshop).Where(x => x.StatusId == 25).FirstAsync();

            return shop;
        }
    }
}
