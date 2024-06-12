using FluentValidation;

namespace MessageService.Features.TextMessages.SendMessage;

public class SendMessageCommandValidator : AbstractValidator<SendMessageCommand>
{
    public SendMessageCommandValidator()
    {
        RuleFor(c => c.TextContent)
            .NotEmpty().WithMessage("TextContent must be not null")
            .MaximumLength(500).WithMessage("Maximum Length 500 char");

        RuleFor(c => c.Attachments).Must(c => c.Count() < 5)
            .WithMessage("Maximum 5 files per request");
    }
}