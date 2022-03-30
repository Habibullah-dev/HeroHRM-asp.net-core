using HeroHRM.Models;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public interface IEmployeeSubordinateRepository
    {
        Task<int> CreateEmployeeSubordinate(EmployeeSubordinateModel model);
        Task DeleteEmployeeSubordinate(int id);
        Task<EmployeeSubordinateModel> FindEmployeeSubordinate(int id);
        Task UpdateEmployeeSubordinate(EmployeeSubordinateModel model);
        Task<EmployeeSubordinateModel> FindEmployeeeID(int id);
    }
}