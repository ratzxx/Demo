using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using User.Application.Common.Interfaces;

namespace User.Application.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateUserCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .MaximumLength(200).WithMessage("Username must not exceed 200 characters.")
                .MustAsync(BeUniqueTitle).WithMessage("The specified Username already taken.");

            RuleFor(v => v.DepartmentId)
               .NotEmpty().WithMessage("Department is required.");
        }

        public async Task<bool> BeUniqueTitle(UpdateUserCommand model, string username, CancellationToken cancellationToken)
        {
            return await _context.Users
                .Where(l => l.Id != model.Id)
                .AllAsync(l => l.UserName != username);
        }
    }
}
