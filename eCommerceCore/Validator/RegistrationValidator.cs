using System.Text.RegularExpressions;
using eCommerceCore.DTO;
using FluentValidation;

namespace eCommerceCore.Validators;

public class RegistrationValidator : AbstractValidator<RegisterUserDTO>
{
    public RegistrationValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email address");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must have at least 6 characters")
            .Custom((password, context) =>
            {
                //special chars
                if (!Regex.IsMatch(password, @"[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>/?]"))
                {
                    context.AddFailure("Password must contain at least one special character");
                }

                //at least one upper case letter
                if (!Regex.IsMatch(password, @"[A-Z]"))
                {
                    context.AddFailure("Password must contain at least one uppercase letter");
                }

                //at least one lower case
                if (!Regex.IsMatch(password, @"[a-z]"))
                {
                    context.AddFailure("Password must contain at least one lowercase letter");
                }
                // at least one digit
                if (!Regex.IsMatch(password, @"[0-9]"))
                {
                    context.AddFailure("Password must contain at least one digit");
                }
            });
        //Enum check for gender options
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required")
            .Length(1, 50).WithMessage("Name must have between 1 and 50 characters");
        RuleFor(x => x.Gender)
            .Must(z => z == 'M' || z == 'F').WithMessage("Gender is invalid")
            .NotNull().WithMessage("Gender cannot be null")
            .NotEmpty().WithMessage("Gender is required");

    }
}