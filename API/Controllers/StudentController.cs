using Business;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Models.Student> Get()
        {
            return new Students().GetAll();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Models.Student Get(int id)
        {
            Students s = new();
            return s.GetByID(id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post(Models.Student student)
        {
            Business.Students s = new();
            s.Create(student);
        }

        // PUT api/<StudentController>/5
        [HttpPut]
        public void Put(Models.Student student)
        {
            Business.Students s = new();
            s.Update(student);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Business.Students s = new();
            s.Delete(id);
        }
    }
}
