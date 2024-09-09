using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSWEBAPI.Data;
using SMSWEBAPI.Models;

namespace SMSWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase { 
      private readonly ApplicationDbContext db;
    public IWebHostEnvironment env;
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
                return Ok(data);
            }
            return Ok("No Such User");

    }

}
}
