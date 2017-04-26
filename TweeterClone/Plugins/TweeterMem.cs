using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweeterClone.App.Entities;
using TweeterClone.Plugins;

namespace TweeterClone.Plugin
{
    public class TweeterMem
    {
        private readonly TweeterContext _context;

        public TweeterMem(TweeterContext context)
        {
            _context = context;

           // if (_context.Users.Count() == 0)
             //   Register(new CoreUser { Username = "test"});
        }

        public void Register(CoreUser user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        /*
        public CoreTweet Edit(int id, String message)
        {
            _context.Tweets.Update(tweet);
            _context.SaveChanges();
        }
        */
        

        public CoreTweet Find(int id)
        {
            return _context.Tweets.FirstOrDefault(t => t.ID == id);

        }

        public IEnumerable<CoreTweet> getAllTweets()
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
