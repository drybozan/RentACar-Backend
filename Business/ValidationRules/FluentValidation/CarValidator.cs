using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.car_name).NotEmpty();
            RuleFor(c => c.car_name).MinimumLength(2);
            RuleFor(c => c.brand_id).NotEmpty();
            RuleFor(c => c.brand_id).NotNull();
            RuleFor(c => c.brand_id).GreaterThan(0);
            RuleFor(c => c.color_id).NotEmpty();
            RuleFor(c => c.color_id).NotNull();
            RuleFor(c => c.color_id).GreaterThan(0);
            RuleFor(c => c.daily_price).NotEmpty();
            RuleFor(c => c.daily_price).NotNull();
            RuleFor(c => c.daily_price).GreaterThan(0);
            RuleFor(c => c.model_year).NotEmpty();
            RuleFor(c => c.model_year).NotNull();

        }
       
    }
}
