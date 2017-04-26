using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweeterClone.App.Entities;

namespace TweeterClone.Plugins
{
    public class TweeterContext : DbContext
    {

        public TweeterContext(DbContextOptions<TweeterContext> options) : base(options)
        {
        }

        public DbSet<CoreTweet> Tweets { get; set; }
        public DbSet<CoreUser> Users { get; set; }
    }
 }

      