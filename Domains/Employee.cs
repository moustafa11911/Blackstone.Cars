using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domains
{
    public class Employee
    {
        public int Id { get; set; }        
        public string Name { get; set; }        
        public string Position { get; set; }
        public int Age { get; set; }
        public List<Car> Cars { get; set; }
    }
}
