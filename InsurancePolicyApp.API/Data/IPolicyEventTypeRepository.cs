using System.Collections.Generic;
using System.Threading.Tasks;
using InsurancePolicyApp.API.Models;

namespace InsurancePolicyApp.API.Data
{
    public interface IPolicyEventTypeRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();
        Task<PolicyEventType> GetPolicyEventType(int id);
        Task<IEnumerable<PolicyEventType>> GetPolicyEventTypes(int policyId);
        Task<IEnumerable<PolicyEventType>> GetPolicyEventTypes();
        Task<bool> VerifyRisk(int riskId, double percent);
    }
}