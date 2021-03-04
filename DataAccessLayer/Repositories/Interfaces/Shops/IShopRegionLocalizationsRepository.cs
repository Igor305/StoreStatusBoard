using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces.Shops
{
    public interface IShopRegionLocalizationsRepository
    {
        public Task<string> getRegion(int? regionId);
    }
}
