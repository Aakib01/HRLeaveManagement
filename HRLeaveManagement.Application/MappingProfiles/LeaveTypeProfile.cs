﻿using AutoMapper;
using HRLeaveManagement.Application.Features.LeaveType.NewFolder.CreateLeaveType;
using HRLeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HRLeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using HRLeaveManagement.Application.Features.LeaveType.UpdateLeaveType;
using HRLeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.MappingProfiles
{
    public class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();

            CreateMap<LeaveType, LeaveTypeDetailsDto>();

            CreateMap<CreateLeaveTypeCommand, LeaveType>();

            CreateMap<UpdateLeaveTypeCommand, LeaveType>();
        }
    }
}
