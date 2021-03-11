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

        [HttpGet]
        public async Task<BoardResponseModel> Board()
        {
            BoardResponseModel boardModelResponses = await _boardService.getBoard();

            return boardModelResponses;
        }

        [HttpGet("Start")]
        public async Task<BoardResponseModel> StartBoard()
        {
            BoardResponseModel boardModelResponses = await _boardService.getStartBoard();

            return boardModelResponses;
        }

        [HttpGet("ShopInfo")]
        public async Task<ShopResponseModel> ShopInfo(int nshop)
        {
            ShopResponseModel shopResponseModel = await _boardService.getShopInfo(nshop);

            return shopResponseModel;
        }


        [HttpGet("DeviceInShop")]
        public async Task<DeviceInShopResponseModel> DeviceInShop(int nshop)
        {
            DeviceInShopResponseModel deviceInShopResponseModel = await _boardService.getDeviceinShop(nshop);

            return deviceInShopResponseModel;
        }
    }
}
