using System.Collections.Generic;
using System.Threading.Tasks;
using InsurancePolicyApp.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;

namespace InsurancePolicyApp.API.Data
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;
        public ClientRepository(DataContext context)
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

        public async Task<Client> GetClient(int id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(p => p.Id == id);

            return client;
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            var clients = await _context.Clients.ToListAsync();

            return clients;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}