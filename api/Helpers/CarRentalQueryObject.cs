using System;
#pragma warning disable 8618,8603,8601,8625,8600,8619,8613
namespace api.Helpers
{
    public class CarRentalQueryObject
    {
        public required string AvailableFromDate { get; set; }
        public required string AvailableUntilDate { get; set; }
        public required string AvailableFromTime { get; set; }
        public required string AvailableUntilTime { get; set; }
        public required string location { get; set; }
    }
}
