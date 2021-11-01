using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(c => c.car_id).NotEmpty();
            RuleFor(c => c.car_id).NotEmpty();
            RuleFor(c => c.car_id).GreaterThan(0);
        }
    }
}
