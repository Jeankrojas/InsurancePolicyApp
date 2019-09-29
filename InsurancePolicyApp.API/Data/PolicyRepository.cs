using System.Collections.Generic;
using System.Threading.Tasks;
using InsurancePolicyApp.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;

namespace InsurancePolicyApp.API.Data
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly DataContext _context;
        public PolicyRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Policy> GetPolicy(int id)
        {
            var policy = await _context.Policies.FirstOrDefaultAsync(p => p.Id == id);

            return policy;
        }

        public async Task<IEnumerable<Policy>> GetPolicies()
        {
            var policies = await _context.Policies.ToListAsync();

            return policies;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}