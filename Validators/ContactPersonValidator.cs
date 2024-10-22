using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Models;
using FluentValidation;

namespace ClassLibrary.Validators
{
    public class ContactPersonValidator : AbstractValidator<ContactPersonEntity>
    {
        public ContactPersonValidator() 
        {
            RuleFor(v => v.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .Length(1, 100).WithMessage("First name must be between 1 and 100 characters.");

            RuleFor(v => v.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .Length(1, 100).WithMessage("Last name must be between 1 and 100 characters.");
        }
    }
}
