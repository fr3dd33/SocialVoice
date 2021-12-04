using FluentValidation;

namespace Application.Issues.Commands.CreateIssue
{
    public class CreateIssueCommandValidator : AbstractValidator<CreateIssueCommand>
    {
        public CreateIssueCommandValidator()
        {
            RuleFor(x => x.Content).NotEmpty().MaximumLength(256);
            RuleFor(x => x.Title).NotEmpty().MaximumLength(64);
        }
    }
}
