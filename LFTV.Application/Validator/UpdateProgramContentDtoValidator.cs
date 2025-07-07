using FluentValidation;
using LFTV.Application.DTOs;

public class UpdateProgramContentDtoValidator : AbstractValidator<UpdateProgramContentDto>
{
    public UpdateProgramContentDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Le titre est obligatoire.")
            .MaximumLength(150).WithMessage("Le titre ne doit pas dépasser 150 caractères.");

        RuleFor(x => x.Type)
            .NotEmpty().WithMessage("Le Type est obligatoire.");

        RuleFor(x => x.EmissionId)
            .GreaterThan(0).WithMessage("L'identifiant de l'émission est obligatoire.");

        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("La Categorie est obligatoire.");

    }
}