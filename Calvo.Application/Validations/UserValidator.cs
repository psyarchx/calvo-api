using FluentValidation;
using Calvo.Application.DTO.Request.Create.General;

namespace Calvo.Application.Validations
{
    public class UserValidator : AbstractValidator<UserCreateDtoRequest>
    {
        public UserValidator()
        {

        }

        //private bool StartsWithDDI(string phoneNumber)
        //{
        //    Regex ddi = new Regex(@"(^[0-9]{2})", RegexOptions.Compiled);
        //    var value = ddi.Matches(phoneNumber);
        //
        //    if (value.Count > 0)
        //    {
        //        return value[0].Value == "55" ? true : false;
        //    }
        //
        //    return false;
        //}
    }
}
