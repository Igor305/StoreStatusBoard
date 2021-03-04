using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces.Shops
{
    public interface IProviderRepository
    {
        public  Task<string> getProviderName(int providerId);
        public Task<string> getProviderPhoneNumber(int providerId);
    }
}
