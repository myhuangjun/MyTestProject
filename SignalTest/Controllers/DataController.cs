using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;

namespace SignalTest.Controllers
{
    public class DataController : ApiController
    {
        public static List<Student> List = new List<Student>();

        [HttpGet]
        public Student GetStudent(int id)
        {
            return List.FirstOrDefault(x => x.Id == id);
        }
        [HttpPost]
        public string PostStudent(Student stu)
        {
            List.Add(stu);
            return "1";
        }

        [HttpDelete]
        public void DeleteStudent(int id)
        {
            var it = List.FirstOrDefault(x => x.Id == id);
            List.Remove(it);
        }


    }


    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
