using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails
{
    public class GetLeaveAllocationDetailsRequestHandler :IRequestHandler<GetLeaveAllocationDetailsQuery,LeaveAllocationDetailsDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;
        public GetLeaveAllocationDetailsRequestHandler(ILeaveAllocationRepository leaveAllocationRepository,IMapper mapper) 
        {
            _leaveAllocationRepository = leaveAllocationRepository; 
            _mapper = mapper;
        }

        public async Task<LeaveAllocationDetailsDto> Handle(GetLeaveAllocationDetailsQuery request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository.GetLeaveAllocationWithDetails(request.Id);
            return _mapper.Map<LeaveAllocationDetailsDto>(leaveAllocation);
        }
    }
}
