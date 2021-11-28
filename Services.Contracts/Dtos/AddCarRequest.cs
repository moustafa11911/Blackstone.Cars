using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Services.Contracts.Dtos
{
    public class AddCarRequest: IValidatableObject
    {
        [Required]
        public string ModelNumber { get; set; }
        [Required]
        public string PlateNumber { get; set; }
        public int BrandId { get; set; }
        public int EmployeeId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (BrandId == default(int))
                yield return new ValidationResult("*", new[] { nameof(BrandId) });

            if (EmployeeId == default(int))
                yield return new ValidationResult("*", new[] { nameof(EmployeeId) });
        }
    }
}
