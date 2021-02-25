using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IRStockRepository
    {
        public Task<List<RStock>> GetAllAsync();
    }
}
