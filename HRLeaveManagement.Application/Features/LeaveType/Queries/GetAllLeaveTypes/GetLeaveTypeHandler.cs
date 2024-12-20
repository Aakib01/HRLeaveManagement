﻿using AutoMapper;
using HRLeaveManagement.Application.Contracts.Logging;
using HRLeaveManagement.Application.Contracts.Persistance;
using HRLeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetLeaveTypeHandler : IRequestHandler<GetLeaveTypeQuery, List<LeaveTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<GetLeaveTypeDetailsQueryHandler> _logger;

        public GetLeaveTypeHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository,IAppLogger<GetLeaveTypeDetailsQueryHandler> logger) 
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _logger = logger;
        }
        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeQuery request, CancellationToken cancellationToken)
        {
            //Query the database
            var leaveTypes = await _leaveTypeRepository.GetAsync();

            //Convert data object to DTO objects
            var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);

            //return list of DTO object
            _logger.LogInformation("Leave types were retrieved successfully");
            return data;
        }
    }
}
