using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistance;
using HRLeaveManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveAllocationCommandHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository,
            ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveAllocationRepository = leaveAllocationRepository;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<Unit> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveAllocationCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid leave allocation Request", validationResult);

            //getLeaveType for allocations
            var leavetype = await _leaveTypeRepository.GetByidAsync(request.LeaveTypeId);

            //Get Employee

            //Get Period

            //Assign Allocations
            var leaveAllocation = _mapper.Map<HRLeaveManagement.Domain.LeaveAllocation>(request);
            await _leaveAllocationRepository.CreateAsync(leaveAllocation);
            return Unit.Value;
        }
    }
}
