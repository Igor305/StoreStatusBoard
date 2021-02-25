using DataAccessLayer.AppContext;
using DataAccessLayer.Repositories.Interfaces;

namespace DataAccessLayer.Repositories.EFRepositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly NetMonitoringContext _netMonitoringContext;

        public GenericRepository(NetMonitoringContext applicationContext)
        {
            _netMonitoringContext = applicationContext;
        }
    }
}
