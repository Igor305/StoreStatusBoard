using DataAccessLayer.AppContext;
using DataAccessLayer.Repositories.Interfaces.Shops;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.EFRepositories.Shops
{
    public class ShopRegionLocalizationsRepository : IShopRegionLocalizationsRepository
    {
        private readonly ShopsContext _shopContext;

        public ShopRegionLocalizationsRepository (ShopsContext shopsContext)
        {
            _shopContext = shopsContext;
        }

        public async Task<string> getRegion(int? regionId)
        {
            string getRegion = await _shopContext.ShopRegionLocalizations.Where(x=>x.ShopRegionId == regionId).Where(x => x.LanguageId == 2).Select(x=>x.Name).FirstAsync();
            return getRegion;
        }
    }
}
