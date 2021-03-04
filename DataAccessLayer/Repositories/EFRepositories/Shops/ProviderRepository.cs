using DataAccessLayer.AppContext;
using DataAccessLayer.Repositories.Interfaces.Shops;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.EFRepositories.Shops
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly ShopsContext _shopContext;

        public ProviderRepository (ShopsContext shopsContext)
        {
            _shopContext = shopsContext;
        }

        public async Task<string> getProviderName(int providerId)
        {
            string providerName = await _shopContext.Providers.Where(x => x.Id == providerId).Select(x=>x.Name).FirstAsync();

            return providerName;
        }

        public async Task<string> getProviderPhoneNumber(int providerId)
        {
            string providerPhoneNumber = await _shopContext.Providers.Where(x => x.Id == providerId).Select(x => x.PhoneNumber).FirstAsync();

            return providerPhoneNumber;
        }
    }
}
