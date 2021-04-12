using BusinessLogicLayer.Models.Response;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace StoreStatusBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IBoardService _boardService;
        public BoardController(IBoardService boardService)
        {
            _boardService = boardService;
        }

        [HttpGet()]
        public async Task<BoardResponseModel> getBoard()
        {
            BoardResponseModel responseModel = await _boardService.getBoard();

            return responseModel;
        }

        [HttpGet("GetStatus")]
        public async Task<StatusResponseModel> GetStatus(int nshop)
        {
            StatusResponseModel statusResponseModel = await _boardService.getStatus(nshop);

            return statusResponseModel;
        }

        [HttpGet("ShopInfo")]
        public async Task<ShopResponseModel> ShopInfo(int nshop)
        {
            ShopResponseModel shopResponseModel = await _boardService.getShopInfo(nshop);

            return shopResponseModel;
        }

        [HttpGet("ShopStatusForDay")]
        public async Task<StatusForDayResponseModel> ShopStatusForDay(int nshop)
        {
            StatusForDayResponseModel statusForDayResponseModel = await _boardService.getStatusForDay(nshop);

            return statusForDayResponseModel;
        }


        [HttpGet("DeviceInShop")]
        public async Task<DeviceInShopResponseModel> DeviceInShop(int nshop)
        {
            DeviceInShopResponseModel deviceInShopResponseModel = await _boardService.getDeviceinShop(nshop);

            return deviceInShopResponseModel;
        }
    }
}
