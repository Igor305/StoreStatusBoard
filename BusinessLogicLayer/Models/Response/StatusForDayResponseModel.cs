using System.Collections.Generic;

namespace BusinessLogicLayer.Models.Response
{
    public class StatusForDayResponseModel
    {
        public List<MonitoringModel> monitorings { get; set; }

        public StatusForDayResponseModel()
        {
            monitorings = new List<MonitoringModel>();
        }
    }
}
