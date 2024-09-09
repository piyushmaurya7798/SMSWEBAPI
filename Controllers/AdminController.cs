using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.Models;
using SMSWEBAPI.Data;
using SMSWEBAPI.Models;

namespace SMSWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public IWebHostEnvironment env;
        public AdminController(ApplicationDbContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }
        [Route("AddStudent")]
        [HttpPost]
        public IActionResult AddStudent(Student s)
        {
            db.Students.Add(s);
            var username=s.username;
            string lastTwoDigits = s.Phone.Substring(s.Phone.Length - 2);
            var password=s.username+lastTwoDigits;
            string urole = "Student";
            User u=new User()
            { 
                username = username,
                Password = password,
                URole = urole
            };
            db.Users.Add(u);
            db.SaveChanges();
            return Ok(s);
        }
        
        [Route("AddTeacher")]
        [HttpPost]
        public IActionResult AddTeacher(Teacher s)
        {
            db.Teachers.Add(s);
            var username = s.username;
            string lastTwoDigits = s.Phone.Substring(s.Phone.Length - 2);
            var password = s.username + lastTwoDigits;
            string urole = "Teacher";
            User u = new User()
            {
                username = username,
                Password = password,
                URole = urole
            };
            db.Users.Add(u);
            db.SaveChanges();
            return Ok(s);
        }

        [Route("AddClass")]
        [HttpPost]
        public IActionResult AddClass(Class c)
        {
            db.Classes.Add(c);
            db.SaveChanges();
            return Ok(c);
        }
        [Route("GetTeacher")]
        [HttpGet]
        public IActionResult GetTeacher()
        {
            var data = db.Classes.ToList();
            return Ok(data);
        }
        
        [Route("AddSubject")]
        [HttpPost]
        public IActionResult AddSubject(Subject s)
        {
          var data= db.Subjects.Add(s);
            db.SaveChanges();
            return Ok(data);
        }
        
        [Route("GetNoOfStudents")]
        [HttpGet]
        public IActionResult GetNoOfStudents()
        {
          var data= db.Students.Count();
            return Ok(data);
        }
        [Route("NoOfTeachers")]
        [HttpGet]
        public IActionResult NoOfTeachers()
        {
          var data= db.Teachers.Count();
            return Ok(data);
        }
    }
}