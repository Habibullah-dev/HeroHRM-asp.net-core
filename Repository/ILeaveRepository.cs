using HeroHRM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public interface ILeaveRepository
    {
        Task<int> CreateLeave(LeaveModel model);
        Task DeleteLeave(int id);
        Task<LeaveModel> FindLeaves(int id);
        Task<List<LeaveModel>> GetLeaves();
        Task UpdateLeave(LeaveModel model);
    }
}