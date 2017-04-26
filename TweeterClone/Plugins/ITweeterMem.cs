using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweeterClone.App.Entities;
using TweeterClone.App.Models;

namespace TweeterClone.Plugin
{
    public interface ITweeterMem
    {
        CoreUser Register(CoreUser user);
        CoreTweet addTweet(TweetModel tweet);
        IEnumerable<CoreTweet> getAllTweets();
        CoreTweet FindTweet(int id);
        CoreUser FindUser(string username);
        void RemoveTweet(int id);
        CoreTweet Edit(TweetModel model);

    }
}
