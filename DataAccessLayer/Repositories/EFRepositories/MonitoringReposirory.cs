using DataAccessLayer.AppContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.EFRepositories
{
    public class MonitoringReposirory : GenericRepository<Monitoring>, IMonitoringRepository
    {
        public MonitoringReposirory (ApplicationContext applicationContext): base(applicationContext)
        {

        }

        public async Task<List<Monitoring>> GetAllAsync()
        {
            List<Monitoring> monitorings = await _applicationContext.Monitorings.ToListAsync();

            return monitorings;
        }
    }
}