using System.Collections.Generic;
using System.Threading.Tasks;
using InsurancePolicyApp.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;

namespace InsurancePolicyApp.API.Data
{
    public class PolicyEventTypeRepository : IPolicyEventTypeRepository
    {
        private readonly DataContext _context;
        public PolicyEventTypeRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public async Task<bool> VerifyRisk(int riskId, double percent)
        {
            var risk = await _context.RiskTypes.FirstOrDefaultAsync(r => r.Id == riskId);           
            if (string.Equals("Alto", risk.Name) && percent > 50)
            {
                return false;
            }
            return true;            
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        //Get an especific policy event type by ID
        public async Task<PolicyEventType> GetPolicyEventType(int id)
        {
            var policyEventType = await _context.PolicyEventTypes.Include(p => p.EventType)
                                                                  .Include(p => p.Policy)
                                                                  .Include(p => p.RiskType)
                                                                  .FirstOrDefaultAsync(pe => pe.Id == id);

            return policyEventType;
        }

        //Get a list of policy event types by policy ID
        public async Task<IEnumerable<PolicyEventType>> GetPolicyEventTypes(int policyId)
        {
            var policyEventTypes = await _context.PolicyEventTypes.Include(p => p.EventType)
                                                                  .Include(p => p.Policy)
                                                                  .Include(p => p.RiskType)
                                                                  .Where(p => p.PolicyId == policyId)
                                                                  .ToListAsync();

            return policyEventTypes;
        }

        //Get all the policy event types
        public async Task<IEnumerable<PolicyEventType>> GetPolicyEventTypes()
        {
            var policyEventTypes = await _context.PolicyEventTypes.Include(p => p.EventType)
                                                                  .Include(p => p.Policy)
                                                                  .Include(p => p.RiskType)
                                                                  .ToListAsync();

            return policyEventTypes;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}