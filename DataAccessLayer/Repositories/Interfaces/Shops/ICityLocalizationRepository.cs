using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces.Shops
{
    public interface ICityLocalizationRepository
    {
        public Task<string> getCity(int? cityId);
    }
}
