using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class ColourValidator:AbstractValidator<Colour>
    {
        public ColourValidator()
        {
            RuleFor(c => c.color_name).NotEmpty();
            RuleFor(c => c.color_name).NotNull();
        }
    }
}
