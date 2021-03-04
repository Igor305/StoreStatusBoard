using DataAccessLayer.AppContext;
using DataAccessLayer.Repositories.Interfaces.Shops;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.EFRepositories.Shops
{
    public class TempImportAddressesRepository : ITempImportAddressesRepository
    {
        private readonly ShopsContext _shopsContext;

        public TempImportAddressesRepository(ShopsContext shopsContext)
        {
            _shopsContext = shopsContext;
        }

        public async Task<string> getShopRegion(int? streetId)
        {
            string region = await _shopsContext.TempImportAdresses.Where(x => x.Id == streetId).Select(x => x.Region).FirstAsync();

            return region;
        }

        public async Task<string> getShopCity(int? streetId)
        {
            string city = await _shopsContext.TempImportAdresses.Where(x => x.Id == streetId).Select(x => x.City).FirstAsync();

            return city;
        }
        public async Task<string> getShopStreet(int? streetId)
        {
            string street = await _shopsContext.TempImportAdresses.Where(x => x.Id == streetId).Select(x => x.Street).FirstAsync();

            return street;
        }
    }
}
