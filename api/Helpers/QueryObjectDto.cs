using System;
#pragma warning disable 8618,8603,8601,8625,8600,8619,8613

namespace api.Helpers
{
    public class QueryObjectDto
    {
         public string? source { get; set; }=null;
        public string? destination { get; set; }=null;
        public string? date_of_departure { get; set; }=null;
        public string? seatType { get; set; } = null;

    }
}
