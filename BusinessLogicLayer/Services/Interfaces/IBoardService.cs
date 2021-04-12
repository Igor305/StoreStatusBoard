﻿using BusinessLogicLayer.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IBoardService
    {
        public Task<BoardResponseModel> getBoard();
        public PingRedResponseModel getPingReds();
        public Task<StatusResponseModel> getStatus(int nshop);
        public Task<ShopResponseModel> getShopInfo(int nshop);
        public Task<DeviceInShopResponseModel> getDeviceinShop(int nshop);
        public Task<StatusForDayResponseModel> getStatusForDay(int nshop);
    }
}
