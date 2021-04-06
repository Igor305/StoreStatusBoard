using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces.Shops
{
    public interface IStreetsLocalizationRepository
    {
        public Task<string> getStreet(int? streetId);
    }
}
