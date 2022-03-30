using HeroHRM.Database;
using HeroHRM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public interface IJobTitleRepository
    {
        Task<int> CreateJobTitle(JobTitleModel model);

        Task<List<JobTitleModel>> GetJobTitles();

        Task DeleteJobTitle(int id);

        Task<JobTitleModel> FindJobTitle(int id);
        Task UpdateJobTitle(JobTitleModel model);
    }
}