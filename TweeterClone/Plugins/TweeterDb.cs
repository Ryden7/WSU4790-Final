using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweeterClone.App.Entities;

namespace TweeterClone.Plugins
{
    public class TweeterDb : DbContext
    {
        public string ConnectionString { get; set; }

        public TweeterDb(DbContextOptions<TweeterDb> options) : base(options)
        {
        }

        public DbSet<CoreTweet> Tweets { get; set; }
        public DbSet<CoreUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoreTweet>().ToTable("Tweet");
            modelBuilder.Entity<CoreUser>().ToTable("User");
        }


        public TweeterDb(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;

        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<CoreTweet> GetAllFilms()
        {
            List<CoreTweet> list = new List<CoreTweet>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM TweeterDb", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new CoreTweet()
                        {
                            ID = reader.GetInt32("idTweets"),
                            Message = reader.GetString("title"),
                            Timestamp = reader.GetDateTime("Timestamp"),
                           

                        });
                    }
                }
            }

            return list;
        }
    }
}
