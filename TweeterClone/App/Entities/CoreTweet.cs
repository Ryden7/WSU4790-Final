using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }


    }
}
