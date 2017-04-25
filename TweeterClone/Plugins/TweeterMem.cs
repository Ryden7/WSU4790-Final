using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweeterClone.App.Entities;

namespace TweeterClone.Plugins
{
    public static class TweeterMem
    {

        private static int count;
        private static List<CoreTweet> allTweets = new List<CoreTweet>();
        
        private static Dictionary<String, List<CoreTweet>> user2Tweet = new Dictionary<string, List<CoreTweet>>();

        public static bool Add(String username, CoreTweet n)
        {
            List<CoreTweet> tempList;
            int count = allTweets.FindIndex(x => x.ID == n.ID);
            if (count != -1)
            {
                return false;
            }

            if (doesUserExist(username))
            {
                allTweets.Add(n);
                user2Tweet.TryGetValue(username, out tempList);
                tempList.Add(n);
                return true;
                
            }

            return false;
        }

        // The number of elements removed from the Notes list
        public static int DeleteByID(int ID)
        {
            return allTweets.RemoveAll(x => x.ID == ID);
        }

        private static bool doesUserExist(String username)
        {
            if (user2Tweet.ContainsKey(username))
                return true;
            
            return false;
        }

        public static List<CoreTweet> getListofTweets(String username)
        {
            List<CoreTweet> templist = new List<CoreTweet>();
            user2Tweet.TryGetValue(username, out templist);
            return templist;
        }

        public static CoreUser Register(String username, String Password, String email)
        {
            if (!doesUserExist(username))
            {
                CoreUser user = new CoreUser(username, Password, email);
                
                List<CoreTweet> list = new List<CoreTweet>();
                user2Tweet.Add(username, list);
                return user;
            }

            return null;

        }


    }
}

