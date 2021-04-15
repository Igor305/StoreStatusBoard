using BusinessLogicLayer.Models.Response;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            BoardResponseModel boardResponseModel = await _boardService.getBoard();

            return boardResponseModel;
        }

        [HttpGet("GetPingRed")]
        public PingRedResponseModel getPingRed()
        {
            PingRedResponseModel pingRedResponseModel = _boardService.getPingReds();

            return pingRedResponseModel;
        }

        [HttpGet("GetStatus")]
        public async Task<StatusResponseModel> GetStatus(int nshop)
        {
            StatusResponseModel statusResponseModel = await _boardService.getStatus(nshop);

            return statusResponseModel;
        }

        [HttpGet("GetShopInfo")]
        public async Task<ShopResponseModel> ShopInfo(int nshop)
        {
            ShopResponseModel shopResponseModel = await _boardService.getShopInfo(nshop);

            return shopResponseModel;
        }

        [HttpGet("GetShopStatusForDay")]
        public async Task<StatusForDayResponseModel> ShopStatusForDay(int nshop)
        {
            StatusForDayResponseModel statusForDayResponseModel = await _boardService.getStatusForDay(nshop);

            return statusForDayResponseModel;
        }


        [HttpGet("GetDeviceInShop")]
        public async Task<DeviceInShopResponseModel> DeviceInShop(int nshop)
        {
            DeviceInShopResponseModel deviceInShopResponseModel = await _boardService.getDeviceinShop(nshop);

            return deviceInShopResponseModel;
        }
    }
}
