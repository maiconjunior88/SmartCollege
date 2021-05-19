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
    public class GradeController : ControllerBase
    {
        // GET: api/<GradeController>
        [HttpGet]
        public IEnumerable<Models.Grade> Get()
        {
            return new Business.Grade().GetAll();
        }

        // GET api/<GradeController>/5
        [HttpGet("{id}")]
        public Models.Grade Get(int id)
        {
            Business.Grade s = new();
            return s.GetByID(id);
        }

        // POST api/<GradeController>
        [HttpPost]
        public void Post(Models.Grade grade)
        {
            Business.Grade s = new();
            s.Create(grade);
        }

        // PUT api/<GradeController>/5
        [HttpPut]
        public void Put(Models.Grade grade)
        {
            Business.Grade s = new();
            s.Update(grade);
        }

        // DELETE api/<GradeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Business.Grade s = new();
            s.Delete(id);
        }
    }
}
