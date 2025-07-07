using FluentValidation;
using LFTV.Application.DTOs;

public class CreateEmissionDtoValidator : AbstractValidator<CreateEmissionDto>
{
    public CreateEmissionDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Le titre est obligatoire.")
            .MaximumLength(100).WithMessage("Le titre ne doit pas dépasser 100 caractères.");

        RuleFor(x => x.StartTime)
            .NotEmpty().WithMessage("L'heure de début est obligatoire.");

        RuleFor(x => x.EndTime)
            .NotEmpty().WithMessage("L'heure de fin est obligatoire.")
            .GreaterThan(x => x.StartTime).WithMessage("L'heure de fin doit être après l'heure de début.");

    }
}