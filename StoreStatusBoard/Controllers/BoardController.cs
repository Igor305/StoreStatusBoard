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

        [HttpGet()]
        public async Task<BoardResponseModel> Board()
        {
            BoardResponseModel boardModelResponses = await _boardService.getBoard();

            return boardModelResponses;
        }

        [HttpGet("RecordSession")]
        public async Task<string> RecordSession()
        {
            string result;
            BoardResponseModel boardModelResponses =  await _boardService.getBoard();

            try
            {

                HttpContext.Session.SetString("board", JsonSerializer.Serialize(boardModelResponses));

            }
            catch
            {

                result = "error";

            }
            result = "successful";

            return result;
        }


        [HttpGet("GetSession")]
        public BoardResponseModel GetSession()
        {
            BoardResponseModel boardModelResponses = new BoardResponseModel();
            try
            {


                var board = HttpContext.Session.GetString("board");
                boardModelResponses = JsonSerializer.Deserialize<BoardResponseModel>(board);
            }
            catch
            {
                return boardModelResponses;
            }

            return boardModelResponses;
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
