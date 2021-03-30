using BusinessLogicLayer.Models.Response;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
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

            HttpContext.Session.SetString("board", JsonSerializer.Serialize(boardModelResponses));

                var value = HttpContext.Session.GetString("board");
                boardModelResponses = JsonSerializer.Deserialize<BoardResponseModel>(value);


            return boardModelResponses;
        }

        [HttpGet("Start")]
        public async Task<BoardResponseModel> StartBoard()
        {
            BoardResponseModel boardModelResponses = await _boardService.getStartBoard();

            return boardModelResponses;
        }

        [HttpGet("RecordSession")]
        public async Task<string> RecordSession()
        {
            BoardResponseModel boardModelResponses =  await _boardService.getStartBoard();

            HttpContext.Session.SetString("board", JsonSerializer.Serialize(boardModelResponses));

            string res = "successful";

            return res;
        }


        [HttpGet("GetSession")]
        public BoardResponseModel GetSession()
        {
            var board = HttpContext.Session.GetString("board");
            BoardResponseModel boardModelResponses = JsonSerializer.Deserialize<BoardResponseModel>(board);

            return boardModelResponses;
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
