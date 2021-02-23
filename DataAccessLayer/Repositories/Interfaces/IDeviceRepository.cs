using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IDeviceRepository
    {
        public Task<List<Device>> GetAllAsync();
    }
}
