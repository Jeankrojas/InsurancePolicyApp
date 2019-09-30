using System.Collections.Generic;
using System.Threading.Tasks;
using InsurancePolicyApp.API.Models;

namespace InsurancePolicyApp.API.Data
{
    public interface IClientRepository
    {
        void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<Client>> GetClients();
         Task<Client> GetClient(int id);
    }
}