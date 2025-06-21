using System;

namespace api.Helpers
{
    public class CarRentalQueryObject
    {
        public string AvailableFromDate { get; set; }
        public string AvailableUntilDate { get; set; }
        public string AvailableFromTime { get; set; }
        public string AvailableUntilTime { get; set; }
        public string location { get; set; }
    }
}
