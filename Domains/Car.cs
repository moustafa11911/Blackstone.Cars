using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public class Car
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string ModelNumber { get; set; }
        public string PlateNumber { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public Brand Brand { get; set; }
    }
}
