using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator: AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.user_id).NotEmpty();
            RuleFor(c => c.user_id).NotNull();
            RuleFor(c => c.user_id).GreaterThan(0);
            RuleFor(c => c.company_name).NotEmpty();
            RuleFor(c => c.company_name).NotNull();
            RuleFor(c => c.company_name).MinimumLength(3);
            RuleFor(c => c.company_name).MaximumLength(30);
        }
    }
}
