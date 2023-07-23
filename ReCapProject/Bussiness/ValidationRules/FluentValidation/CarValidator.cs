using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.ModelYear).NotEmpty();

            RuleFor(p => p.BrandId).NotEmpty();

            RuleFor(p => p.ColorId).NotEmpty();

            RuleFor(p => p.Id).NotEmpty();

            RuleFor(p => p.DailyPrice)
                .NotEmpty()
                .GreaterThan(0)
                .GreaterThanOrEqualTo(500).When(p => p.BrandId == 1);

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("Description cannot be empty.")
                .MinimumLength(10)
                .Must(StartsWithNumber).WithMessage("Description must start with modelyear.");
        }

        private bool StartsWithNumber(string desc)
        {
            if (string.IsNullOrWhiteSpace(desc))
                return false;

            char firstChar = desc.TrimStart()[0];
            return char.IsDigit(firstChar);
        }
    }
}
