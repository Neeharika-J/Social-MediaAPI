using FluentValidation;
using SMApi.DTO;

namespace SMApi.Validators
{
    public class UserValidator:AbstractValidator<UserCreateDTO>
    {
        public UserValidator()
        {
            RuleFor(udto => udto.email).EmailAddress().NotNull();
            RuleFor(udto => udto.phone).NotNull().Length(10);
        }
        
    }
}
