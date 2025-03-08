using Microsoft.EntityFrameworkCore;
using ModelLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Context
{
    public class HelloGreetingContext : DbContext
    {
        public HelloGreetingContext(DbContextOptions<HelloGreetingContext> option) : base(option)
        {

        }
        public virtual DbSet<Entity.UserEntity> Greetings { get; set; }

       
        

    }
}
