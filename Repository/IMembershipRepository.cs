using HeroHRM.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeroHRM.Repository
{
    public interface IMembershipRepository
    {
        Task<int> CreateMembership(MembershipModel model);
        Task DeleteMembership(int id);
        Task<MembershipModel> FindMembership(int id);
        Task<List<MembershipModel>> GetMembership();
        Task UpdateMembership(MembershipModel model);
    }
}