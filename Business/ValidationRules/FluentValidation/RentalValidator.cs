using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator: AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.car_id).NotEmpty();
            RuleFor(r => r.car_id).NotNull();
            RuleFor(r => r.car_id).GreaterThan(0);
            RuleFor(r => r.customer_id).NotEmpty();
            RuleFor(r => r.customer_id).NotNull();
            RuleFor(r => r.customer_id).GreaterThan(0);
            RuleFor(r => r.rent_date).NotEmpty();
            RuleFor(r => r.rent_date).NotNull();
        }
    }
}
