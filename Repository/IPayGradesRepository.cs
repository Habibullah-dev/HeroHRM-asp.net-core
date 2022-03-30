using HeroHRM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public interface IPayGradesRepository
    {
        Task<int> CreatePayGrade(PayGradesModel model);
        Task DeletePayGrade(int id);
        Task<PayGradesModel> FindPayGrade(int id);
        Task<List<PayGradesModel>> GetPayGrades();
        Task UpdatePayGrade(PayGradesModel model);
    }
}