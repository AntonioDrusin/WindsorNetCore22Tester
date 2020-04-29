using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplication2._2.Services;

namespace WebApplication2._2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase, IDisposable
    {
        private readonly ITransientService _transient;
        private readonly IOtherTransient _otherTransient;

        public ValuesController(ITransientService transient, IOtherTransient otherTransient)
        {
            _transient = transient;
            _otherTransient = otherTransient;
            Console.WriteLine("Controller created");
        }


        ~ValuesController()
        {
            Console.WriteLine("Controller destroyed");
            ReleaseUnmanagedResources();
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private void ReleaseUnmanagedResources()
        {
            // TODO release unmanaged resources here
        }

        public void Dispose()
        {
            Console.WriteLine("Controller disposed");
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }
    }
}
