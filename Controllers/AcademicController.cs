using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SMS.Models;
using SMSWEBAPI.Data;
using SMSWEBAPI.Models;
using System.Text;
using System.Xml;

namespace SMSWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public AcademicController(ApplicationDbContext db)
        {
            this.db = db;
        }

        // Curriculum Management
        [Route("GetAllCurricula")]
        [HttpGet]
        public IActionResult GetCurricula()
        {
            var curricula = db.Curriculums.ToList();
            return Ok(curricula);
        }



        [Route("AddCurriculum")]
        [HttpPost]
        public IActionResult AddCurriculum(Curriculum curriculum)
        {
            db.Curriculums.Add(curriculum);
            db.SaveChanges();
            return Ok("Curriculum added successfully");
        }
        [Route("AddTimeTable")]
        [HttpPost]

        public IActionResult AddTime(TimeTable tt)
        {
            db.TimeTables.Add(tt);
            db.SaveChanges();
            return Ok("TimeTable Added Successfully");
        }

        [Route("GetTimeTable")]
        [HttpGet]
        public IActionResult GetTime()
        {
            var curricula = db.TimeTables.ToList();
            return Ok(curricula);
        }
        [Route("AddSub")]
        [HttpPost]

        public IActionResult AddSubject(Subject s)
        {
            db.Subjects.Add(s);
            db.SaveChanges();
            return Ok("Subject Added Successfully");
        }
        [Route("GetSub")]
        [HttpGet]
        public IActionResult GetSubjects()
        {
            var curricula = db.Subjects.ToList();
            return Ok(curricula);
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
        [Route("ApproveTeacherLeave/{id}")]
        [HttpPut]
        public IActionResult ApproveTeacherLeave(int id)
        {
            db.Database.ExecuteSqlRaw($"Exec ApproveTeacherLeave '{id}'");
            return Ok("Leave request approved successfully.");
        }

        [Route("RejectTeacherLeave/{id}")]
        [HttpPut]
        public IActionResult RejectTeacherLeave(int id)
        {
            db.Database.ExecuteSqlRaw($"EXEC RejectTeacherLeave '{id}'");
            return Ok("Leave request rejected successfully.");
        }
    }
}