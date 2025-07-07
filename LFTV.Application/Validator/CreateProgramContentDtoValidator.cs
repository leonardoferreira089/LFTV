using FluentValidation;
using LFTV.Application.DTOs;

public class CreateProgramContentDtoValidator : AbstractValidator<CreateProgramContentDto>
{
    public CreateProgramContentDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Le titre est obligatoire.")
            .MaximumLength(150).WithMessage("Le titre ne doit pas dépasser 150 caractères.");

        RuleFor(x => x.Type)
            .NotEmpty().WithMessage("Le type est obligatoire.");

        RuleFor(x => x.EmissionId)
            .GreaterThan(0).WithMessage("L'identifiant de l'émission est obligatoire.");

        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("Le type est obligatoire.");

    }
}