using System.ComponentModel.DataAnnotations;

namespace Domains
{
    public class Road
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
