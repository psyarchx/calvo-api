using FluentValidation;
using Calvo.Application.DTO.Request;

namespace Calvo.Application.Validations
{
    public class AuthenticateValidator : AbstractValidator<AuthenticateDtoRequest>
    {
        public AuthenticateValidator()
        {
            //RuleFor(x => x.Name)
            //    .NotEmpty()
            //    .WithMessage("Username is required.");
            //
            //RuleFor(x => x.Password)
            //    .NotEmpty()
            //    .WithMessage("Password is required.");
        }
    }
}
