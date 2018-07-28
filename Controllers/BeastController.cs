using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BEAST_API.Models;

namespace BEAST_API.Controllers {
    [Route("api")]
    [ApiController]
    public class BeastController : ControllerBase {
        private readonly BeastContext _context;

        public BeastController(BeastContext context) {
            _context = context;

            var role = _context.Roles.Count() == 0 ? new Role { title = "Administrator"} : _context.Roles.First();

            if(_context.Roles.Count() == 0) {
                _context.Roles.Add(role);
                _context.SaveChanges();
            }

            var beast = _context.Beasts.Count() == 0 ? new Beast { firstName = "Lucas", lastName = "Cawkell", role = role} : _context.Beasts.First();

            if(_context.Beasts.Count() == 0) {
                _context.Beasts.Add(beast);
                _context.SaveChanges();
            }

            List<Beast> beasts = new List<Beast>();
            beasts.Add(beast);

            if(_context.Applications.Count() == 0) {
                _context.Applications.Add(new Application { title = "MedNet", beasts = beasts });
                _context.SaveChanges();
            }

        
        }

        [HttpGet("roles")]
        public ActionResult<List<Role>> GetRoles() {
            return _context.Roles.ToList();
        }

        [HttpGet("beasts")]
        public ActionResult<List<Beast>> GetBeasts() {
            return _context.Beasts.ToList();
        }

        [HttpGet("applications")]
        public ActionResult<List<Application>> GetApplications() {
            return _context.Applications.ToList();
        }
    }
}