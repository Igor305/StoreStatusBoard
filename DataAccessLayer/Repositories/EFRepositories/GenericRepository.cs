using DataAccessLayer.AppContext;
using DataAccessLayer.Repositories.Interfaces;

namespace DataAccessLayer.Repositories.EFRepositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationContext _applicationContext;

        public GenericRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
    }
}
