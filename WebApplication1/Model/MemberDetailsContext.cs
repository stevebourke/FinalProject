using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurfProject.Model
{
    //For setting up the database...
    public class MemberDetailsContext : DbContext
    {

        public MemberDetailsContext(DbContextOptions<MemberDetailsContext> options)
            : base(options)
        {
            
        }

        public DbSet<Member> Members { get; set; }


        public DbSet<SurfProfile> SurfProfiles { get; set; }
     

        public DbSet<Message> Messages { get; set; }
    }
}
