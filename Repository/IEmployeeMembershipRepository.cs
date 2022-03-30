using HeroHRM.Models;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public interface IEmployeeMembershipRepository
    {
        Task<int> CreateEmployeeMembership(EmployeeMembershipModel model);
        Task DeleteEmployeeMembership(int id);
        Task<EmployeeMembershipModel> FindEmployeeMembership(int id);
        Task UpdateEmployeeMembership(EmployeeMembershipModel model);
        Task<EmployeeMembershipModel> FindByEmployeeId(int id);
    }
}