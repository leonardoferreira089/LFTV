using FluentValidation;
using LFTV.Application.DTOs;

public class CreateHistoryDtoValidator : AbstractValidator<CreateHistoryDto>
{
    public CreateHistoryDtoValidator()
    {
        RuleFor(x => x.WatchedAt)
            .NotEmpty().WithMessage("La date de visionnage est obligatoire.")
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("La date de visionnage ne peut pas être dans le futur.");

        RuleFor(x => x.ProgramContentId)
            .GreaterThan(0).WithMessage("L'identifiant du contenu programmé est obligatoire.");

        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("L'identifiant de l'utilisateur est obligatoire.");
    }
}