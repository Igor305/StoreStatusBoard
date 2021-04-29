using System.Collections.Generic;

namespace BusinessLogicLayer.Models
{
    public class StatusShopInCacheModel
    {
        public MonitoringModel Provider1 { get; set; }
        public MonitoringModel Provider2 { get; set; }
        public MonitoringModel Sunc { get; set; }
        public string WorkTimeFrom { get; set; }
        public string WorkTimeTo { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public List<ProviderModel> Providers { get; set; }
        public List<MonitoringModel> Devices { get; set; }

        public StatusShopInCacheModel()
        {
            Providers = new List<ProviderModel>();
            Devices = new List<MonitoringModel>();
        }
    }
}