using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Models
{

    public class ResponseModel
    {
        public List<MonitoringModel> monitoringModelsR { get; set; }
        public List<MonitoringModel> monitoringModelsS { get; set; }
        public int amount { get; set; }
    }
}

