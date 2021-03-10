using System.Collections.Generic;

namespace BusinessLogicLayer.Models.Response
{
    public class DeviceInShopResponseModel
    {
        public List<MonitoringModel> Devices { get; set; }
        public DeviceInShopResponseModel()
        {
            Devices = new List<MonitoringModel>();
        }
    }
}
