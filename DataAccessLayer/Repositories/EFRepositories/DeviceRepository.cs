using DataAccessLayer.AppContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.EFRepositories
{
    public class DeviceRepository : GenericRepository<Device> , IDeviceRepository
    {
        public DeviceRepository (ApplicationContext applicationContext) : base (applicationContext)
        {

        }

        public async Task<List<Device>> GetAllAsync()
        {
            List<Device> devices = await _applicationContext.Devices.ToListAsync();
            int r = 56;
            return devices;
        }
    }
}
