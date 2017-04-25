using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TweeterClone.App.Entities;
using TweeterClone.Plugins;

namespace TweeterClone.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [Route("/")]
       public IActionResult Index()
        {
            return Ok("I am Groot");
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<CoreTweet> GetAllTweets(String username)
        {
           return TweeterMem.getListofTweets(username);
            /*
            return new List<CoreTweet>{
                new CoreTweet{Message="This is a tweet"},
                new CoreTweet{Message="This is another tweet"}
             };
             */
            
        }



        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            if (id > 1)
            {
                return NotFound();
            }
            return Ok(new CoreTweet { Message = $"here's a note whose id is... {id}" });
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
