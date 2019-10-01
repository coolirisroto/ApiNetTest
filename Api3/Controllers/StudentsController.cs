using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service;
using System.Collections;
using System.Collections.Generic;

namespace Api3.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class StudentsController : ControllerBase

    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        // GET api/values
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "item1", "item2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            return Ok(_studentService.Get(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Student model)
        {
            return Ok(
                _studentService.Add(model)
            );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Student model)
        {
            return Ok(
                _studentService.Add(model)
            );
        }

        // DELETE api/values/5
        [HttpDelete()]
        public IActionResult Delete(int id)
        {
            return Ok(
                _studentService.Delete(id)
            );
        }


    }
}
