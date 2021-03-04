using DataAccessLayer.AppContext;
using DataAccessLayer.Repositories.Interfaces.Shops;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.EFRepositories.Shops
{
    public class ShopProvidersRepository : IShopProvidersRepository
    {
        private readonly ShopsContext _shopContext;

        public ShopProvidersRepository (ShopsContext shopsContext)
        {
            _shopContext = shopsContext;
        }

        public async Task<List<int>> getShopProvider(int nstock)
        {
            List<int> nproviders = await _shopContext.ShopProviders.Where(x => x.ShopId == nstock).Select(x => x.ProviderId).ToListAsync();

            return nproviders;
        }
    }
}
