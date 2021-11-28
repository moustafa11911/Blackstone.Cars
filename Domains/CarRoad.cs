using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public class CarRoad
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int RoadId { get; set; }
        public int CardId { get; set; }
        public decimal PassCost { get; set; }
        public Car Car { get; set; }
        public Road Road { get; set; }
        public Card Card { get; set; }
        public List<CarRoadLog> Logs { get; set; }
    }
}
