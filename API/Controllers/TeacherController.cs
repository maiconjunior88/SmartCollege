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
    public class TeacherController : ControllerBase
    {
        // GET: api/<TeacherController>
        [HttpGet]
        public IEnumerable<Models.Teacher> Get()
        {
            return new Teachers().GetAll();
        }

        // GET api/<TeacherController>/5
        [HttpGet("{id}")]
        public Models.Teacher Get(int id)
        {
            Teachers s = new();
            return s.GetByID(id);
        }

        // POST api/<TeacherController>
        [HttpPost]
        public void Post(Models.Teacher teacher)
        {
            Teachers s = new();
            s.Create(teacher);
        }

        // PUT api/<TeacherController>/5
        [HttpPut]
        public void Put(Models.Teacher teacher)
        {
            Teachers s = new();
            s.Update(teacher);
        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Teachers s = new();
            s.Delete(id);
        }
    }
}
