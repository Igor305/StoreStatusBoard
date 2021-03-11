using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces.NetMonitoring
{
    public interface IRStockRepository
    {
        public Task<int> getAmountShop();
    }
}
