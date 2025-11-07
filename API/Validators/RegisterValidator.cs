// using FluentValidation;
// using WeightAggregationApi.Models.DTOs;

// namespace WeightAggregationApi.Validators;

// public class RegisterValidator : AbstractValidator<RegisterDto>
// {
//     public RegisterValidator()
//     {
//         RuleFor(x => x.Email).NotEmpty().EmailAddress();
//         RuleFor(x => x.Password).NotEmpty().MinimumLength(8).Matches("[A-Z]").Matches("[0-9]");
//     }
// }