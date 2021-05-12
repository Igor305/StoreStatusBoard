﻿using BusinessLogicLayer.Models.Response;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IBoardService
    {
        public BoardResponseModel getBoard();
        public BoardResponseModel getRoutersTrue();
        public BoardResponseModel getSTrue();
        public Task inCache();
        public PingRedResponseModel getPingReds();
        public Task<StatusResponseModel> getStatus(int nshop);
        public Task<ShopResponseModel> getShopInfo(int nshop);
        public Task<DeviceInShopResponseModel> getDeviceinShop(int nshop);
        public Task<StatusForDayResponseModel> getStatusForDay(int nshop);
    }
}
