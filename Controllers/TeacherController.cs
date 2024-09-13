using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSWEBAPI.Data;
using SMSWEBAPI.Models;

namespace SMSWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public IWebHostEnvironment env;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TeacherController(ApplicationDbContext db, IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            this.db = db;
            this.env = env;
            this._httpContextAccessor = httpContextAccessor;
        }
        [Route("AddLeave")]
        [HttpPost]

        public IActionResult AddLeave(TeacherLeave tl)
        {
            db.TeacherLeave.Add(tl);
            db.SaveChanges();
            return Ok("leave Added Successfully");
        }
        [Route("GetLeave/{id}")]
        [HttpGet]
        public IActionResult GetLeave(int id)
        {
            var student = db.TeacherLeave.Find(id);

            return Ok("Leave");
        }
    }
}
