using HeroHRM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public interface IDepartmentRepository
    {
        Task<int> CreateDepartment(DepartmentModel model);
        Task DeleteDepartment(int id);
        Task<DepartmentModel> FindDepartment(int id);
        Task<List<DepartmentModel>> GetDepartment();
        Task UpdateDepartment(DepartmentModel model);
    }
}