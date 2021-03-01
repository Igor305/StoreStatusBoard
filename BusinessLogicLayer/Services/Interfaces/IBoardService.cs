using BusinessLogicLayer.Models;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IBoardService
    {
        public Task<ResponseModel> GetBoard();
    }
}
