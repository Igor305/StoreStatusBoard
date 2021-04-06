using DataAccessLayer.AppContext;
using DataAccessLayer.Repositories.Interfaces.Shops;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.EFRepositories.Shops
{
    public class CityLocalizationRepository : ICityLocalizationRepository
    {
        private readonly ShopsContext _shopsContext;
        public CityLocalizationRepository(ShopsContext shopsContext)
        {
            _shopsContext = shopsContext;
        }

        public async Task<string> getCity(int? cityId)
        {
            string city = await _shopsContext.CitiesLocalizations.Where(x => x.CityId == cityId && x.LanguageId == 2).Select(x => x.Name).FirstOrDefaultAsync();

            return city;
        }
    }
}
