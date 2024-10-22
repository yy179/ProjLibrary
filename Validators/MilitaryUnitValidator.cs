using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Models;
using FluentValidation;

namespace ClassLibrary.Validators
{
    public class MilitaryUnitValidator : AbstractValidator<MilitaryUnitEntity>
    {
        public MilitaryUnitValidator() 
        { 
            RuleFor(mu => mu.Name).NotEmpty().WithMessage("Name is required.")
                .Length(1, 20).WithMessage("Name must be between 1 and 18 characters.");
        }
    }
}
