using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweeterClone.App.Entities;

namespace TweeterClone.Plugin
{
    public interface ITweeterMem
    {
        CoreUser Register(String username, String password, String email);
        IEnumerable<CoreTweet> getAllTweets(String username);
        CoreTweet Find(int id);
        void Remove(int id);
        CoreTweet Edit(int id, String message);

    }
}
