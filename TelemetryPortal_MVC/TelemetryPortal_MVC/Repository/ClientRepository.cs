using Microsoft.EntityFrameworkCore;
using TelemetryPortal_MVC.Data;
using TelemetryPortal_MVC.Models;

namespace TelemetryPortal_MVC.Repository
{
    public class ClientRepository
    {
        private readonly TechtrendsContext _context;

        // Constructor injection for the DbContext
        public ClientRepository(TechtrendsContext context)
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
