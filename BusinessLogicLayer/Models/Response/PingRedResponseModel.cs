using System.Collections.Generic;

namespace BusinessLogicLayer.Models.Response
{
    public class PingRedResponseModel
    {
        public List<PingRedModel> pingRedModels { get; set; }

        public PingRedResponseModel()
        {
            pingRedModels = new List<PingRedModel>();
        }
    }
}
