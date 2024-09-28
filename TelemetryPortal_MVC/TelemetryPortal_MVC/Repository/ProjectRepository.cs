using Microsoft.EntityFrameworkCore;
using TelemetryPortal_MVC.Data;
using TelemetryPortal_MVC.Models;

namespace TelemetryPortal_MVC.Repository
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(TechtrendsContext context) : base(context) 
        {
            
        }

        public Project GetMostRecentProject()
        {
            return _context.Projects.OrderByDescending(project => project.ProjectCreationDate).FirstOrDefault();
        }
    }
}
