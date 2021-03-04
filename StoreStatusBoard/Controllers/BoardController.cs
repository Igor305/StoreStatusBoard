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

        [HttpGet("Shop")]
        public async Task<ShopResponseModel> Shop(int nshop)
        {
            ShopResponseModel shopResponseModel = await _boardService.getShopInfo(nshop);

            return shopResponseModel;
        }
    }
}
