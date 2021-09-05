using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().MinimumLength(3).WithMessage("Kullanıcı adı en az 3 karakter içermelidir.");
            RuleFor(u => u.LastName).NotEmpty().MinimumLength(2).WithMessage("Kullanıcı soyadı en az 2 karakter içermelidir.");
           // RuleFor(u => u.Email).EmailAddress(EmailValidationMode.Net4xRegex).WithMessage("Lütfen geçerli bir email adresi giriniz");
        }
    }
}
