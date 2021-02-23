using System;

namespace DataAccessLayer.Entities
{
    public class Monitoring
    {
        public string Device { get; }
        public int Stock { get; }
        public int Status { get; }
        public string IpAddress { get; }
        public DateTime LogTime { get;}
        public int ResponseTime { get; }
        public int TTL { get; }
    }
}
