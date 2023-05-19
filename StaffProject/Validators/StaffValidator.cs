using FluentValidation;
using StaffProject.Data.Context;
using StaffProject.Schema;

namespace StaffProject.Service.Validators;

public class StaffValidator : AbstractValidator<StaffRequest>
{
    public StaffValidator() {

        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.");
        RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.FirstName).MaximumLength(30).WithMessage("Maximum length for First Name is 30.");
        RuleFor(x => x.LastName).MaximumLength(30).WithMessage("Maximum length for Last Name is 30.");  
        RuleFor(x => x.Email).MaximumLength(100).WithMessage("Maximum length for Email is 100.");     
        RuleFor(x => x.Phone).MaximumLength(30).WithMessage("Maximum length for Phone is 30.");
        RuleFor(x => x.AddressLine1).MaximumLength(70).WithMessage("Maximum length for Address Line 1 is 70.");
        RuleFor(x => x.City).MaximumLength(20).WithMessage("Maximum length for City is 20.");
        RuleFor(x => x.Country).MaximumLength(40).WithMessage("Maximum length for Country is 40.");
        RuleFor(x => x.Province).MaximumLength(30).WithMessage("Maximum length for Province is 30.");


    }
    

}
