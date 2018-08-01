using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BEAST_API.Models;


namespace BEAST_API.Repositories {
    public class ApplicationRepository : IApplicationRepository {

        private readonly BeastContext _db;

        public ApplicationRepository(BeastContext db) {
            _db = db;
        }

        public async Task<Application> Add(Application application)
        {
            
            await _db.Applications.AddAsync(application);
            await _db.SaveChangesAsync();
            return application;
        }

        public async Task<Application> GetApplication(int id)
        {
            return await _db.Applications.FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task<List<Application>> GetApplications()
        {
            return await _db.Applications.ToListAsync();
        }

        public async Task<Beast> GetBeast(int id)
        {
            return await _db.Beasts.FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task<List<Beast>> GetBeasts()
        {
            return await _db.Beasts.ToListAsync();
        }
    }
}
