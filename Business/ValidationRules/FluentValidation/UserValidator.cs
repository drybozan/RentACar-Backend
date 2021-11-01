using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.firstname).NotEmpty().WithMessage("İsim boş geçilemez"); 
            RuleFor(u => u.firstname).NotNull();
            RuleFor(u => u.firstname).MinimumLength(2).WithMessage("İsim en az 2 karakterden oluşmalıdır"); 
            RuleFor(u => u.firstname).MaximumLength(15);

            RuleFor(u => u.lastname).NotEmpty().WithMessage("Soyad boş geçilemez"); 
            RuleFor(u => u.lastname).NotNull();
            RuleFor(u => u.lastname).MinimumLength(2).WithMessage("Soyisim en az 2 karakterden oluşmalıdır"); 
            RuleFor(u => u.lastname).MaximumLength(15);
          

            RuleFor(u => u.email).NotEmpty().WithMessage("Email alanı boş bırakılmaz."); 
            RuleFor(u => u.email).NotNull();
            RuleFor(u => u.email).Must(isEmail).WithMessage("Geçersiz email formatı");
        }

        private bool isEmail(string arg)
        {
            return (arg.Contains("@") && arg.Contains(".com"));
        }
    }
}

