using System;

namespace BusinessLogicLayer.Models
{
    public class MonitoringModel
    {
        public string Device { get; set; }
        public int? Stock { get; set; }
        public int? Status { get; set; }
        public int? StatusS { get; set; }
        public int? isGrey { get; set; }
        public string IpAddress { get; set; }
        public DateTime? LogTime { get; set; }
        public string StrLogTime { get;  set; }
        public int? ResponseTime { get; set; }
        public int? TTL { get; set; }
    }
}
