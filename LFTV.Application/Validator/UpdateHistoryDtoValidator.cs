using FluentValidation;
using LFTV.Application.DTOs;

public class UpdateHistoryDtoValidator : AbstractValidator<UpdateHistoryDto>
{
    public UpdateHistoryDtoValidator()
    {
        RuleFor(x => x.WatchedAt)
            .NotEmpty().WithMessage("La date de visionnage est obligatoire.")
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("La date de visionnage ne peut pas être dans le futur.");
    }
}