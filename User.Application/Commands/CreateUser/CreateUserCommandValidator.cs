using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using User.Application.Common.Interfaces;

namespace User.Application.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateUserCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .MaximumLength(200).WithMessage("Username must not exceed 200 characters.")
                .MustAsync(BeUniqueTitle).WithMessage("The specified Username already taken.");

            RuleFor(v => v.DepartmentId)
                .NotEmpty().WithMessage("Department is required.");
        }

        public async Task<bool> BeUniqueTitle(string username, CancellationToken cancellationToken)
        {
            return await _context.Users
                .AllAsync(l => l.UserName != username);
        }

    }
}
