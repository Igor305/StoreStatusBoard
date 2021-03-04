using DataAccessLayer.Entities.Shops;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces.Shops
{
    public interface IShopsRepository
    {
        public Task<Shop> getShop(int nshop);
    }
}
