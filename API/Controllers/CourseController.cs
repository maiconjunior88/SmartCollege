using Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        // GET: api/<CourseController>
        [HttpGet]
        public IEnumerable<Models.Course> Get()
        {
            return new Courses().GetAll();
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public Models.Course Get(int id)
        {
            Courses s = new();
            return s.GetByID(id);
        }

        // POST api/<CourseController>
        [HttpPost]
        public void Post(Models.Course course)
        {
            Courses s = new();
            s.Create(course);
        }

        // PUT api/<CourseController>/5
        [HttpPut]
        public void Put(Models.Course course)
        {
            Courses s = new();
            s.Update(course);
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Courses s = new();
            s.Delete(id);
        }
    }
}
