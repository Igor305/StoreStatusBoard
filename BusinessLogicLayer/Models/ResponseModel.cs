using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Models
{

    public class ResponseModel
    {
        public List<MonitoringModel> monitoringModels { get; set; }
        public int amount { get; set; }
    }
}

