using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweeterClone.App.Entities;

namespace TweeterClone.Plugins
{
    public class Dbinitializer
    {
        public static void Initialize(TweeterDb context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }


            var users = new CoreUser[]
            {
           // new CoreUser{Username="Carson", Password=("asdf"), Email = "asdf"};
           TweeterMem.Register("asdf", "asdf", "asdf")
            

            };

            foreach (CoreUser s in users)
            {
                context.Users.Add(s);
            }
            context.SaveChanges();

    }
}
}
