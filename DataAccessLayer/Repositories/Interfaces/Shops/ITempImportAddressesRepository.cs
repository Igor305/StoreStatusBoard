using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces.Shops
{
    public interface ITempImportAddressesRepository
    {
        public Task<string> getShopRegion(int? streetId);
        public  Task<string> getShopCity(int? streetId);
        public  Task<string> getShopStreet(int? streetId);
    }
}
