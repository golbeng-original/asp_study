

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ex1.Controllers
{
    public class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public int score { get; set; }
    }

    public class Subject
    {
        public int id { get; set; }
        public string subjectName { get; set; }
    }

    public class StudentDto
    {
        public Student student { get; set; }
        public List<Subject> subjects { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class Ex2Controller : ControllerBase
    {

        // 단일 값 전송
        [HttpGet]
        //[Produces("application/json", Type = typeof(WeatherForecast))] // appliation/json으로 고정
        //[Consumes("application/json")] // 응답 body가 application/json으로 고정
        public Student Get()
        {
            return new Student() {
                id = 1,
                name = "name!!",
                score = 100
            };
        }

        // 리스트 값 전송
        [HttpGet("list")]
        public IEnumerable<Student> GetList()
        {
            return new List<Student>()
            {
                new Student(){ id = 0, name = "s1", score = 10},
                new Student(){ id = 1, name = "s2", score = 30},
                new Student(){ id = 2, name = "s3", score = 60},
            };
        }

        // 복합 형태
        [HttpGet("complex")]
        public StudentDto GetComplex()
        {

            return new StudentDto()
            {
                student = new Student()
                {
                    id = 0,
                    name = "student1",
                    score = 100,
                },
                subjects = new List<Subject>()
                {
                    new Subject(){id = 1, subjectName = "math"},
                    new Subject(){id = 2, subjectName = "english"},
                }
            };
        }

    }
}