using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TweeterClone.Plugin;
using TweeterClone.App.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TweeterClone.Controllers
{
    [Route("api/[controller]")]
    public class CoreUserController : Controller
    {

        private readonly ITweeterMem _TweeterRepo;

        public CoreUserController(ITweeterMem TweeterRepo)
        {
            _TweeterRepo = TweeterRepo;
        }
 #region snippet_GetAll
        /*
        
        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return _todoRepository.GetAll();
        }
        */

        [HttpGet("{id}", Name = "GetTweet")]
        public IActionResult GetById(int id)
        {
            var item = _TweeterRepo.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        #endregion
        #region snippet_Create
        [HttpPost]
        public IActionResult Create([FromBody] CoreUser user)
        {
            if (user == null)
            {
                return BadRequest();
            }

           // _TweeterRepo.Register(user);

            return CreatedAtRoute("GetUser", new { id = user.Username }, user);
        }
        #endregion

        #region snippet_Update
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CoreTweet tweet)
        {
            if (tweet == null || tweet.ID != id)
            {
                return BadRequest();
            }

            var todo = _TweeterRepo.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

          
            todo.Message = tweet.Message;

            return new NoContentResult();
        }
        #endregion

        #region snippet_Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _TweeterRepo.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _TweeterRepo.Remove(id);
            return new NoContentResult();
        }
        #endregion
    }
}

