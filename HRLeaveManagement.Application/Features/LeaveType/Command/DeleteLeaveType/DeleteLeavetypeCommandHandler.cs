using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistance;
using HRLeaveManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveType.DeleteLeaveType
{
    public class DeleteLeavetypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteLeavetypeCommandHandler(ILeaveTypeRepository leaveTypeRepository) =>        
            _leaveTypeRepository = leaveTypeRepository;
        
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var leaveTypeToDelete = await _leaveTypeRepository.GetByidAsync(request.Id);

            // verify that record exists
            if (leaveTypeToDelete == null)
                throw new NotFoundException(nameof(LeaveType),request.Id);

            // remove from database
            await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);

            // return record id
            return Unit.Value;
        }
    }
}
