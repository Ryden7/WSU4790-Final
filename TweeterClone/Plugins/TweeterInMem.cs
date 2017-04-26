using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweeterClone.App.Entities;
using TweeterClone.Plugin;

namespace TweeterClone.Plugins
{
    public class TweeterInMem : ITweeterMem
    {
        private Dictionary<CoreUser, List<CoreTweet>> user2Tweet;
        private List<CoreTweet> tweets;
        private Dictionary<String, CoreUser> username2User;

        public TweeterInMem()
        {
            user2Tweet = new Dictionary<CoreUser, List<CoreTweet>>();
        }

        public CoreTweet Edit(int id, String message)
        {
            CoreTweet tweet = Find(id);

            tweet.Message = message;

            return tweet;
        }

        public CoreTweet Find(int id)
        {
            return tweets.Find(tweet => tweet.ID == id);
        }

        public IEnumerable<CoreTweet> getAllTweets(String username)
        {
            CoreUser user = getUser(username);

            user2Tweet.TryGetValue(user, out List<CoreTweet> value);
            return value;

        }

        private CoreUser getUser(string Username)
        {
            if (username2User.Keys.Contains(Username))
            {
                username2User.TryGetValue(Username, out CoreUser value);
                return value;
            }

            return null;
        }

        public CoreUser Register(String username, String password, String email)
        {
            CoreUser newUser = new CoreUser(username, password, email);
            List<CoreTweet> tweets = new List<CoreTweet>();
            username2User.Add(username, newUser);

            user2Tweet.Add(newUser, tweets);
            

            return newUser;
            
        }


        public void Remove(int id)
        {
            tweets.Remove(Find(id));
        }

        
    }
}
