using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts.Dtos
{
    public class CarDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string ModelNumber { get; set; }
        public string PlateNumber { get; set; }
        public int EmployeeId { get; set; }
    }
}
