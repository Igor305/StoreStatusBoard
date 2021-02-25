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
        public DeviceRepository (NetMonitoringContext netMonitoringContext) : base (netMonitoringContext)
        {

        }

        public async Task<List<Device>> GetAllAsync()
        {
            List<Device> devices = await _netMonitoringContext.Devices.ToListAsync();
            return devices;
        }
    }
}
