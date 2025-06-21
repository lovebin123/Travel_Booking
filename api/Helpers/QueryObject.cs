using System;

namespace api.Helpers
{
    public class QueryObject
    {
         public string? source { get; set; }=null;
        public string? destination { get; set; }=null;
        public string? date_of_departure { get; set; }=null;
        public string? seatType { get; set; } = null;

    }
}
