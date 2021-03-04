using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Models.Response
{

    public class BoardResponseModel
    {
        public List<MonitoringModel> monitoringModels { get; set; }
        public int amount { get; set; }
    }
}

