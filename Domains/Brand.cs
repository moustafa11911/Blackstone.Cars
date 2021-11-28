using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domains
{
    public class Brand
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
