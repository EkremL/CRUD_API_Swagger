using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentController : ControllerBase
    {
        private static List<Student> students = new List<Student>()
            {
                new Student()
                {
                    Id = 1,
                    Name = "Ekrem",
                    Age = 21,
                    City = "Ankara",
                },
                new Student()
                {
                    Id = 2,
                    Name = "Burak",
                    Age = 22,
                    City = "Belgrad",
                },
                new Student()
                {
                    Id = 3,
                    Name = "Hasan",
                    Age = 45,
                    City = "Antalya",
                }

            };

        [HttpGet]
        [Route("Getstudents")]
        public async Task<ActionResult<Student>> Getstudents()
        {
           
            return Ok(students);
        }
        [HttpGet]
        [Route("Getstudent")]
        public async Task<ActionResult<Student>> Getstudents(int id)
        {
            var student = students.Find(x=> x.Id == id);
            if (student == null)
                return BadRequest("No student found!");


            return Ok(student);
        }
        [HttpPost]
        [Route("addstudent")]
        public async Task<ActionResult<Student>> AddStudent(Student request)
        {
            students.Add(request);
            
            return Ok(students);
        }
        [HttpPut]
        [Route("updatestudent")]
        public async Task<ActionResult<Student>> UpdateStudent(Student request)
        {
            
            var student = students.Find(x => x.Id == request.Id);
            if (student == null)
                return BadRequest("No student found!");
            student.Name = request.Name;
            student.Age = request.Age;
            student.City = request.City;

            return Ok(student);
        }
        [HttpDelete]
        [Route("deletestudent")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {

            var student = students.Find(x => x.Id == id);
            if (student == null)
                return BadRequest("No student found!");
            students.Remove(student);

            return Ok(students);
        }

    }
}
