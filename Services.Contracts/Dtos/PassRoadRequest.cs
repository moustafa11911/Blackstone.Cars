using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Services.Contracts.Dtos
{
    public class PassRoadRequest: IValidatableObject
    {
        public int CarId { get; set; }
        public int RoadId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CarId == default(int))
                yield return new ValidationResult("*", new[] { nameof(CarId) });

            if (RoadId == default(int))
                yield return new ValidationResult("*", new[] { nameof(RoadId) });
        }
    }
}
