using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Models.Response
{
    public class ShopResponseModel
    {
        public DateTime WorkTimeFrom { get; set; }
        public DateTime WorkTimeTo { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public List<ProviderModel> Providers { get; set; }

        public ShopResponseModel()
        {
            Providers = new List<ProviderModel>();
        }
    }
}
