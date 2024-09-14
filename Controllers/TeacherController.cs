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

        public TeacherController(ApplicationDbContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }
        [Route("AddLeave")]
        [HttpPost]

        public IActionResult AddLeave(TeacherLeave tl)
        {
            db.TeacherLeave.Add(tl);
            db.SaveChanges();
            return Ok("leave Added Successfully");
        }
        [Route("GetLeave")]
        [HttpGet]
        public IActionResult GetLeave()
        {
            var student = db.TeacherLeave.ToList();

            return Ok(student);
        }
        
        [Route("GetLeave/{id}")]
        [HttpGet]
        public IActionResult GetLeave(int id)
        {
            var student = db.TeacherLeave.Where(x=>x.TeacherId==id.ToString());

            return Ok(student);
        }
    }
}
