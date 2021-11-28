using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public class CarRoadLog
    {
        public int Id { get; set; }
        public int CarRoadId { get; set; }
        public DateTime PassTime { get; set; }
        public decimal Cost { get; set; }
        public CarRoad CarRoad { get; set; }
    }
}
