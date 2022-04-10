using Card.Api.Models.Requests;
using FluentValidation;
using System;

namespace Card.Api.Models.Validators
{
    public class CardRequestValidator : AbstractValidator<CardRequest>
    {
        public CardRequestValidator()
        {
            RuleFor(s => s.CardNumber)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Card Number Doesn't Empty")
                .Must(s => s.Length == 15)
                .WithMessage("Card Number Doesn't Empty")
                .When(c => c.CardType == CardType.AmericanExpress)
                .Must(s => s.Length == 16)
                .When(c => c.CardType == CardType.Visa || c.CardType == CardType.MasterCard);

            RuleFor(s => s.CVC)
               .Cascade(CascadeMode.Stop)
               .NotEmpty()
               .WithMessage("Card CVC Doesn't Empty")
               .Must(s => s.Length == 4)
               .When(c => c.CardType == CardType.AmericanExpress)
               .Must(s => s.Length == 3)
               .When(c => c.CardType == CardType.Visa || c.CardType == CardType.MasterCard);

            RuleFor(s => s.Date)
             .Cascade(CascadeMode.Stop)
             .NotEmpty()
             .WithMessage("Card Date Doesn't Empty")
             .Custom((date, context) =>
             {
                 var dateNow = DateTime.Now;
                 var month = Convert.ToInt32(date.Substring(0, 2));
                 var year = Convert.ToInt32(date.Substring(3));
                 if (year < dateNow.Year || (year - dateNow.Year) * 12 + month - dateNow.Month <= 0)
                     context.AddFailure("Expired Card");
             });

            RuleFor(c => c.CardType)
               .Cascade(CascadeMode.Stop)
               .IsInEnum()
               .WithMessage("Incorrect Card Type");
        }
    }
}
