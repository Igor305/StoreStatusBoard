using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Models.Response
{
    public class StatusResponseModel
    {
        public MonitoringModel Provider1 { get; set; }
        public MonitoringModel Provider2 { get; set; }
        public MonitoringModel Sunc { get; set; }
    }
}
