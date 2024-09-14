using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.Models;
using SMSWEBAPI.Data;
using SMSWEBAPI.Models;
using static System.Net.Mime.MediaTypeNames;
using System.Net.Mail;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

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
            var username = s.username;
            string lastTwoDigits = s.Phone.Substring(s.Phone.Length - 2);
            var password = s.username + lastTwoDigits;
            string urole = "Student";
            var d = db.Classes.Where(x => x.ClassName == s.ClassId).SingleOrDefault();
            var data = db.Fees.Where(x => x.ClassId == d.ClassId).SingleOrDefault();
            s.Fees = data.FeesValue;
            db.Students.Add(s);
            db.SaveChanges();
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
            var data = db.Teachers.ToList();
            Response.ContentType = "application/json";
            return Ok(data);
        }
        
        [Route("CheckExistingEmailId/{username}")]
        [HttpGet]
        public IActionResult CheckExistingEmailId(string username)
        {
            var data = db.Users.Where(x => x.username == username).SingleOrDefault();
            if (data == null) 
            {
                return Ok("Good to Go");
            }
            return Ok("notgood");
        }

        [Route("AddSubject")]
        [HttpPost]
        public IActionResult AddSubject(Subject s)
        {
            var data = db.Subjects.Add(s);
            db.SaveChanges();
            return Ok(data);
        }

        [Route("GetNoOfStudents")]
        [HttpGet]
        public IActionResult GetNoOfStudents()
        {
            var data = db.Students.Count();
            return Ok(data);
        }
        [Route("NoOfTeachers")]
        [HttpGet]
        public IActionResult NoOfTeachers()
        {
            var data = db.Teachers.Count();
            return Ok(data);
        }
        [Route("Application")]
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Application([FromForm] ApplicationViewModel a)
        {
            //db.Applications.Add(a);
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Images");
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + a.LatestRecords.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await a.LatestRecords.CopyToAsync(stream);
            }
            SMS.Models.Application s = new SMS.Models.Application()
            {
                Email = a.Email,
                Phone = a.Phone,
                HighestQualification = a.HighestQualification,
                Grade = a.Grade,
                LatestRecords = filePath,
                ApplyingFor = a.ApplyingFor,
                Date = a.Date
            };
            db.Applications.Add(s);
            db.SaveChanges();
            return Ok("Added Application Successfull");
        }
        [Route("GetApplication")]
        [HttpGet]
        public async Task<IActionResult> GetApplication()
        {
            var data = db.Applications.ToList();
            return Ok(data);
        }

        [HttpPost("SendEmails")]
        public IActionResult SendEmails([FromBody] EmailRequest request)
        {
            if (request == null || request.Emails == null || !request.Emails.Any() || string.IsNullOrEmpty(request.Message))
            {
                return BadRequest("Invalid request.");
            }

            try
            {
                foreach (var email in request.Emails)
                {
                    // Logic for sending email
                    SendEmail(email, request.Message);
                }

                return Ok(new { success = true, message = "Emails sent successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private void SendEmail(string email, string message)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("piyushmaurya7798@gmail.com", "qbposjoyllyywcld"),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("piyushmaurya7798@gmail.com"),
                Subject = "Application Notification",
                Body = message,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(email);
            smtpClient.Send(mailMessage);
        }

        [Route("Fees")]
        [HttpPost]
        public IActionResult AddFees(Fees s)
        {
            db.Fees.Add(s);
            db.SaveChanges();
            return Ok();
        }

        [Route("GetClass")]
        [HttpGet]
        public IActionResult GetClass()
        {
            var data = db.Classes.ToList();
            return Ok(data);
        }

        [Route("GetAllEvents")]
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            return await db.Events.ToListAsync();
        }

        [Route("GetAllEvents/{id}")]
        [HttpGet]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var eventItem = await db.Events.FindAsync(id);

            if (eventItem == null)
            {
                return NotFound();
            }
            return eventItem;
        }

        [Route("CreateEvent")]
        [HttpPost]
        public async Task<ActionResult<Event>> CreateEvent([FromBody]Event eventItem)
        {
            db.Events.Add(eventItem);
            await db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEvent), new { id = eventItem.EventId }, eventItem);
        }

        [Route("UpdateEvent/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateEvent(int id, Event eventItem)
        {
            if (id != eventItem.EventId)
            {
                return BadRequest();
            }

            db.Entry(eventItem).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok("Updated");
        }

        [Route("DeleteEvent/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var eventItem = await db.Events.FindAsync(id);
            if (eventItem == null)
            {
                return NotFound();
            }

            db.Events.Remove(eventItem);
            await db.SaveChangesAsync();

            return NoContent();
        }

        private bool EventExists(int id)
        {
            return db.Events.Any(e => e.EventId == id);
        }

    }
}