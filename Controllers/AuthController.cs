using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSWEBAPI.Data;
using SMSWEBAPI.Models;

namespace SMSWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    { 
      private readonly ApplicationDbContext db;
        public IWebHostEnvironment env;
             private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthController(ApplicationDbContext db, IWebHostEnvironment env)
        {
        this.db = db;
        this.env = env;
        }
    [Route("Login")]
    [HttpPost]
    public IActionResult Login(User u)
    {
        var data=db.Users.Where(x=>x.username==u.username&&x.Password==u.Password&&x.URole==u.URole).SingleOrDefault();
            if (data != null)
            {
                //if (data.URole == "Student")
                //{
                //    var suser = db.Students.Where(x => x.username == data.username).SingleOrDefault();
                //    //HttpContext.Session.SetString("sid", suser.userid.ToString());
                //    //HttpContext.Session.SetString("suser", suser.username);
                //}
                //else if (data.URole == "Teacher")
                //{
                //    var suser = db.Teachers.Where(x => x.username == data.username).SingleOrDefault();
                //    HttpContext.Session.SetString("sid", suser.TeacherId.ToString());
                //    HttpContext.Session.SetString("suser", suser.username);
                //}
                //}else if (data.URole == "Librarian")
                //{
                //    var suser = db.Teachers.Where(x => x.username == data.username).SingleOrDefault();
                //    HttpContext.Session.SetString("suser", suser.TeacherId.ToString());
                //    HttpContext.Session.SetString("suser", suser.username);
                //}
                //else if (data.URole == "Admin")
                //{
                //    HttpContext.Session.SetString("suser", data.username);
                //}
                return Ok(data);

            }
            return NotFound("No Such User");

    }
        [Route("GetStudentId/{username}")]
        [HttpGet]
        public IActionResult GetStudentId(string username) 
        {
            var data= db.Students.Where(x => x.username == username).SingleOrDefault().userid;
            return Ok(data);
        }
        
        [Route("GetTeacherId/{username}")]
        [HttpGet]
        public IActionResult GetTeacherId(string username) 
        {
            var data= db.Teachers.Where(x => x.username == username).SingleOrDefault().TeacherId;
            return Ok(data);
        }
}
}
