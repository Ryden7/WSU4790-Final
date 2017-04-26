using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweeterClone.App.Entities;
using TweeterClone.App.Models;
using TweeterClone.Plugin;

namespace TweeterClone.Plugins
{
    public class ContextInMem : ITweeterMem
    {
        private readonly TweeterContext _context;

        public ContextInMem(TweeterContext context)
        {
            _context = context;
        }

        public CoreTweet addTweet(TweetModel model)
        {
            int idforTweet = _context.Tweets.Count();
            idforTweet++;

           CoreTweet Newtweet = new CoreTweet { ID = idforTweet, Message = model.Message };
        
            _context.Tweets.Add(Newtweet);
            _context.SaveChanges();
            return Newtweet;
        }

        public CoreTweet Edit(TweetModel tweet)
        {
            CoreTweet tweetToUpdate = FindTweet(tweet.ID);
            tweetToUpdate.Message = tweet.Message;
            tweetToUpdate.Timestamp = tweetToUpdate.Timestamp;
            _context.Update(tweetToUpdate);
            _context.SaveChanges();
            return tweetToUpdate;
        }

        public CoreTweet FindTweet(int id)
        {
            return _context.Tweets.SingleOrDefault(x => x.ID == id);
        }


        public CoreUser FindUser(string username)
        {
            return _context.Users.SingleOrDefault(x => x.Username == username);
        }

        public IEnumerable<CoreTweet> getAllTweets()
        {
            return _context.Tweets.ToList();
        }

        public CoreUser Register(CoreUser user)
        {
            var addedUser = _context.Add(user);
            _context.SaveChanges();
            user.Username = addedUser.Entity.Username;
            return user;
        }

        public void RemoveTweet(int id)
        {
            CoreTweet tweetToRemove = FindTweet(id);
            _context.Remove(tweetToRemove);
            _context.SaveChanges();
        }
    }
}
