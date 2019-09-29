using System.Collections.Generic;
using System.Threading.Tasks;
using InsurancePolicyApp.API.Models;

namespace InsurancePolicyApp.API.Data
{
    public interface IPolicyRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<Policy>> GetPolicies();
         Task<Policy> GetPolicy(int id);
    }
}