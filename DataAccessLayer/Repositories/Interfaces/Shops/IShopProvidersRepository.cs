using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces.Shops
{
    public interface IShopProvidersRepository
    {
        public Task<List<int>> getShopProvider(int nstock);
    }
}
