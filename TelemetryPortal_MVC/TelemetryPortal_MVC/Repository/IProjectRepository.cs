using TelemetryPortal_MVC.Models;

namespace TelemetryPortal_MVC.Repository
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        Project GetMostRecentProject();
    }
}
