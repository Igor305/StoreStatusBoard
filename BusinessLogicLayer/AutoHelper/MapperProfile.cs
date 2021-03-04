using AutoMapper;
using BusinessLogicLayer.Models;
using DataAccessLayer.Entities.NetMonitoring;
using DataAccessLayer.Entities.Shops;

namespace BusinessLogicLayer.AutoHelper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Monitoring, MonitoringModel>();
            CreateMap<Shop, ShopModel>();
        }
    }
}
