using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TweeterClone.App.Entities
{
    public class CoreTweet
    {
        /*
        public readonly int ID;

        public int GetID()
        {    
            return ID;
        }
        */

       public int ID { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }


    }
}
