using BusinessLogicLayer.Models.Response;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IBoardService
    {
        public Task<BoardResponseModel> getStartBoard();
        public Task<BoardResponseModel> getBoard();
        public Task<ShopResponseModel> getShopInfo(int nshop);
        public Task<DeviceInShopResponseModel> getDeviceinShop(int nshop);
    }
}
