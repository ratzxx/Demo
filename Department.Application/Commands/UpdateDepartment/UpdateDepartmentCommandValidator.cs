﻿using Department.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Department.Application.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateDepartmentCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(200).WithMessage("Title must not exceed 200 characters.")
                .MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.");
        }

        public async Task<bool> BeUniqueTitle(UpdateDepartmentCommand model, string title, CancellationToken cancellationToken)
        {
            return await _context.Departments
                .Where(l => l.Id != model.Id)
                .AllAsync(l => l.Title != title);
        }
    }
}
