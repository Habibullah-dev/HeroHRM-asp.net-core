using HeroHRM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public interface IJobCategoryRepository
    {
        Task<int> CreateJobCategory(JobCategoryModel model);
        Task DeleteJobCategory(int id);
        Task<JobCategoryModel> FindJobCategory(int id);
        Task<List<JobCategoryModel>> GetJobCategory();
        Task UpdateJobCategory(JobCategoryModel model);
    }
}