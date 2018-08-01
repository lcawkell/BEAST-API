using BEAST_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BEAST_API.Repositories {
    public interface IApplicationRepository {
        Task<Application> GetApplication(int id);
        Task<List<Application>> GetApplications();
        Task<Application> Add(Application application);
        Task<List<Beast>> GetBeasts();
        Task<Beast> GetBeast(int id);
    }
}