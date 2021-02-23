using BusinessLogicLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IBoardService
    {
        public Task<List<ResponseModel>> GetBoard();
    }
}
