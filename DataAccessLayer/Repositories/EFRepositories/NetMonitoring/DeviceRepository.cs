using DataAccessLayer.AppContext;
using DataAccessLayer.Entities.NetMonitoring;
using DataAccessLayer.Repositories.Interfaces.NetMonitoring;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.EFRepositories.NetMonitoring
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly NetMonitoringContext _netMonitoringContext;
        public DeviceRepository (NetMonitoringContext netMonitoringContext) 
        {
            _netMonitoringContext = netMonitoringContext;
        }

        public async Task<List<Device>> getAllAsync()
        {
            List<Device> devices = await _netMonitoringContext.Devices.ToListAsync();
            return devices;
        }
    }
}
