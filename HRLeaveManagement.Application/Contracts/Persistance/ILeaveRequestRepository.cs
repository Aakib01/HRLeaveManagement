﻿using HRLeaveManagement.Domain;

namespace HRLeaveManagement.Application.Contracts.Persistance
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
        Task<List<LeaveRequest>> GetLeaveRequestWithDetails();
        Task<List<LeaveRequest>> GetLeaveRequestWithDetails(string userId);
    }

}