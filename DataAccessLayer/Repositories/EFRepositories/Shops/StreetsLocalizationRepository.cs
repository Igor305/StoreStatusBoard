using DataAccessLayer.AppContext;
using DataAccessLayer.Repositories.Interfaces.Shops;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.EFRepositories.Shops
{
    public class StreetsLocalizationRepository : IStreetsLocalizationRepository
    {
        public readonly ShopsContext _shopContext;
        public StreetsLocalizationRepository(ShopsContext shopsContext)
        {
            _shopContext = shopsContext;
        }

        public async Task<string> getStreet(int? streetId)
        {
            string street = await _shopContext.StreetsLocalizations.Where(x => x.StreetId == streetId && x.LanguageId == 2).Select(x => x.Name).FirstOrDefaultAsync();

            return street;
        }
    }
}
