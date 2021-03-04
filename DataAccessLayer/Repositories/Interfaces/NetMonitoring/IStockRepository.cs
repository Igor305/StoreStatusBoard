using DataAccessLayer.Entities.NetMonitoring;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces.NetMonitoring
{
    public interface IStockRepository
    {
        public Task<List<Stock>> getAllAsync();
    }
}
