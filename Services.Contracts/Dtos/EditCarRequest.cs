using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts.Dtos
{
    public class EditCarRequest
    {
        public string ModelNumber { get; set; }
        public string PlateNumber { get; set; }
        public int BrandId { get; set; }
        public int EmployeeId { get; set; }
    }
}
