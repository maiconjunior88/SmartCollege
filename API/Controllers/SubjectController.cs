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
    public class SubjectController : ControllerBase
    {
        // GET: api/<SubjectController>
        [HttpGet]
        public IEnumerable<Models.SubjectList> Get()
        {
            return new Business.Subjects().GetAll();
        }

        // GET api/<SubjectController>/5
        [HttpGet("{id}")]
        public Models.Subject Get(int id)
        {
            Business.Subjects s = new();
            return s.GetByID(id);
        }

        // POST api/<SubjectController>
        [HttpPost]
        public void Post(Models.SubjectList subject)
        {
            Business.Subjects s = new();
            s.Create(subject);
        }

        // PUT api/<SubjectController>/5
        [HttpPut]
        public void Put(Models.Subject subject)
        {
            Business.Subjects s = new();
            s.Update(subject);
        }

        // DELETE api/<SubjectController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Business.Subjects s = new();
            s.Delete(id);
        }
    }
}
