using FluentValidation;
using LFTV.Application.DTOs;

public class UpdateCalendarEntryDtoValidator : AbstractValidator<UpdateCalendarEntryDto>
{
    public UpdateCalendarEntryDtoValidator()
    {
        RuleFor(x => x.Date)
            .NotEmpty().WithMessage("La date est obligatoire.");

        RuleFor(x => x.EmissionId)
            .GreaterThan(0).WithMessage("L'identifiant de l'émission est obligatoire.");
    }
}