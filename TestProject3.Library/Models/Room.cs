using System;
using System.Collections.Generic;

namespace TestProject3
{
    public partial class Room
    {
        public int Roomid { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public int? Vacancy { get; set; }
        public int? Occupancy { get; set; }
        public string Gender { get; set; }
    }
}
