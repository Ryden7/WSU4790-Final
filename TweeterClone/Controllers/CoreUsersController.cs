using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TweeterClone.App.Entities;
using TweeterClone.Plugins;
using TweeterClone.Plugin;
using TweeterClone.App.Models;

namespace TweeterClone.Controllers
{
    [Route("/[controller]")]
    public class CoreUsersController : Controller
    {
        private readonly ITweeterMem _tweeterRepo;

        public CoreUsersController(ITweeterMem tweeterRepo)
        {
            _tweeterRepo = tweeterRepo;    
        }

        [HttpGet("/CoreUsers/")]
        public IEnumerable<CoreTweet> getAll()
        {
            return _tweeterRepo.getAllTweets();
        }
        // GET: CoreTweet
        [HttpGet("/CoreUsers/{id}", Name = "GetTweet")]
        public CoreTweet Get(int id)
        {
            return _tweeterRepo.FindTweet(id);
        }

        // GET: CoreUsers
       [HttpGet("/CoreUsers/{id}", Name = "GetUser")]
        public CoreUser Get(string id)
        {
            return _tweeterRepo.FindUser(id);
        }

        [HttpGet("/CoreUsers/get/{id}")]
        public CoreTweet Get2(int id)
        {
            return _tweeterRepo.FindTweet(id);
        }



        // POST book
        [HttpPost("/CoreUsers/register")]
        public IActionResult Register([FromBody]CoreUser user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            CoreUser createdUser = _tweeterRepo.Register(user);


            return CreatedAtRoute("GetUser", new { id = user.Username } , createdUser);
        }

        // POST book
        [HttpPost("/CoreUsers/Tweet")]
        public IActionResult Tweet([FromBody]TweetModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (_tweeterRepo.FindUser(model.Username).Equals(null))
                return BadRequest();



            if (model.Message.Length > 140)
                return BadRequest();

            CoreTweet newTweet = _tweeterRepo.addTweet(model);


            return CreatedAtRoute("GetTweet", new { id = model.Username }, newTweet);
        }




        // PUT book/5
        [HttpPut("/CoreUsers/Update")]
        public IActionResult Put([FromBody]TweetModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (model.Message.Length > 140)
                return BadRequest();

            _tweeterRepo.Edit(model);

            CoreTweet newTweet = _tweeterRepo.FindTweet(model.ID);

            return CreatedAtRoute("GetTweet", new { id = model.Username }, newTweet);


        }


        // DELETE book/5
        [HttpDelete("/CoreUsers/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var book = _tweeterRepo.FindTweet(id);
            if (book == null)
            {
                return NotFound();
            }
            _tweeterRepo.RemoveTweet(id);


            return NoContent();
        }
    }
}
