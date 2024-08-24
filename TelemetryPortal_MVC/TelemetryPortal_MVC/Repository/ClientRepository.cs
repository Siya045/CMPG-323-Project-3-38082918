using Microsoft.EntityFrameworkCore;
using TelemetryPortal_MVC.Data;
using TelemetryPortal_MVC.Models;

namespace TelemetryPortal_MVC.Repository
{
    /* public class ClientRepository
     {
         private readonly Techtrends2Context _context = new Techtrends2Context();

         public IEnumerable<Client> GetAll()
         {
             return  _context.Clients.ToList();
         }
     }*/

    public class ClientRepository
    {
        private readonly Techtrends2Context _context;

        // Constructor injection for the DbContext
        public ClientRepository(Techtrends2Context context)
        {
            _context = context;
        }

        // Asynchronous method to get all clients
        public async Task<IEnumerable<Client>> GetAll()
        {
            return  _context.Clients.ToList();
        }
    }
}
