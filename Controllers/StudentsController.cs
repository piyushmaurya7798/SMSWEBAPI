using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSWEBAPI.Data;
using SMSWEBAPI.Models;

namespace SMSWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
            private readonly ApplicationDbContext db;
            public StudentsController(ApplicationDbContext db)
            {
                this.db = db;
            }



            [Route("GetAllStudents")]
            [HttpGet]
            public IActionResult GetStudents()
            {
                var students = db.Students.ToList();
                return Ok(students);
            }

            [Route("GetStudent/{id}")]
            [HttpGet]
            public IActionResult GetStudent(int id)
            {
                var student = db.Students.Find(1);
                return Ok(student);
            }

            [Route("AddStudent")]
            [HttpPost]
            public IActionResult AddStudent(Student student)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return Ok("Student added successfully");
            }

            [Route("UpdateStudent")]
            [HttpPut]
            public IActionResult UpdateStudent(Student student)
            {
                db.Students.Update(student);
                db.SaveChanges();
                return Ok("Student updated successfully");
            }

            [Route("DeleteStudent/{id}")]
            [HttpDelete]
            public IActionResult DeleteStudent(int id)
            {
                var student = db.Students.Find(id);
                db.Students.Remove(student);
                db.SaveChanges();
                return Ok("Student deleted successfully");
            }

            // Enrollment Management

            [Route("GetAllClasses")]
            [HttpGet]
            public IActionResult GetClasses()
            {
                var classes = db.Classes.ToList();
                return Ok(classes);
            }

            [Route("GetClass/{id}")]
            [HttpGet]
            public IActionResult GetClass(int id)
            {
                var classInfo = db.Classes.Find(id);
                return Ok(classInfo);
            }



            // Attendance Tracking

            [Route("GetAllAttendances")]
            [HttpGet]
            public IActionResult GetAttendances()
            {
                var attendances = db.StudentAttendance.ToList();
                return Ok(attendances);
            }

            [Route("AddAttendance")]
            [HttpPost]
            public IActionResult AddAttendance(StudentAttendance attendance)
            {
                db.StudentAttendance.Add(attendance);
                db.SaveChanges();
                return Ok("Attendance added successfully");
            }

            [Route("GetAttendance/{id}")]
            [HttpGet]
            public IActionResult GetAttendance(int id)
            {
                var attendance = db.StudentAttendance.Find(id);
                if (attendance == null)
                {
                    return NotFound("Attendance not found");
                }
                return Ok(attendance);
            }

            // Performance Management

            [Route("AddPerformance")]
            [HttpPost]
            public IActionResult AddPerformance(Performance performance)
            {
                db.Performances.Add(performance);
                db.SaveChanges();
                return Ok("Performance added successfully");
            }

            [Route("GetAllPerformances")]
            [HttpGet]
            public IActionResult GetPerformances()
            {
                var performances = db.Performances.ToList();
                return Ok(performances);
            }

            [Route("GetPerformance/{id}")]
            [HttpGet]
            public IActionResult GetPerformance(int id)
            {
                var performance = db.Performances.Find(id);
                if (performance == null)
                {
                    return NotFound("Performance record not found");
                }
                return Ok(performance);
            }

            // Homework Assignments

            [Route("GetAllHomeworkAssignments")]
            [HttpGet]
            public IActionResult GetHomeworkAssignments()
            {
                var assignments = db.HomeworkAssignments.ToList();
                return Ok(assignments);
            }



            [Route("AddHomeworkAssignment")]
            [HttpPost]
            public IActionResult AddHomeworkAssignment(HomeworkAssignment assignment)
            {
                db.HomeworkAssignments.Add(assignment);
                db.SaveChanges();
                return Ok("Homework assignment added successfully");
            }

            // Disciplinary Records

            [Route("GetAllDisciplinaryRecords")]
            [HttpGet]
            public IActionResult GetDisciplinaryRecords()
            {
                var records = db.DisciplinaryRecords.ToList();
                return Ok(records);
            }

            [Route("GetDisciplinaryRecord/{id}")]
            [HttpGet]
            public IActionResult GetDisciplinaryRecord(int id)
            {
                var record = db.DisciplinaryRecords.Find(id);
                if (record == null)
                {
                    return NotFound("Disciplinary record not found");
                }
                return Ok(record);
            }

            [Route("AddDisciplinaryRecord")]
            [HttpPost]
            public IActionResult AddDisciplinaryRecord(DisciplinaryRecord record)
            {
                db.DisciplinaryRecords.Add(record);
                db.SaveChanges();
                return Ok("Disciplinary record added successfully");
            }
            [Route("GetTeacher")]
            [HttpGet]
            public IActionResult GetTeacher()
            {
                var data = db.Teachers.ToList();
                Response.ContentType = "application/json";
                return Ok(data);
            }
            [Route("GetClass")]
            [HttpGet]
            public IActionResult GetClass()
            {
                var data = db.Classes.ToList();
                return Ok(data);
            }

        }
    }
