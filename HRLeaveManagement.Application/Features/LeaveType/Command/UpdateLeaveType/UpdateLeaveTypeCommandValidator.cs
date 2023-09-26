using FluentValidation;
using HRLeaveManagement.Application.Contracts.Persistance;
using HRLeaveManagement.Application.Features.LeaveType.NewFolder.CreateLeaveType;
using HRLeaveManagement.Application.Features.LeaveType.UpdateLeaveType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveType.Command.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandValidator : AbstractValidator<UpdateLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(LeaveTypeMustExist);

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(70).WithMessage("{PropertyName must be fewer than 70 characters}");

            RuleFor(p => p.DefaultDays)
                .GreaterThan(100).WithMessage("{PropetyName} cannot exceed 100")
                .LessThan(1).WithMessage("{PropertyName} cannot be less than 1");

            RuleFor(q => q).
                MustAsync(LeaveTypeNameUnique)
                .WithMessage("Leave type already exists");
        }

        private async Task<bool> LeaveTypeMustExist(int id, CancellationToken token)
        {
            var leaveType = await _leaveTypeRepository.GetByidAsync(id);
            return leaveType != null;
        }

        private async Task<bool> LeaveTypeNameUnique(UpdateLeaveTypeCommand command, CancellationToken token)
        {
            return await _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
        }


    }
}
