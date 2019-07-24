﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class MemberContext : DbContext
    {


        public MemberContext(DbContextOptions<MemberContext> options)
            : base(options)
        { }


        public DbSet<Member> Members { get; set; }


        public DbSet<SurfAlert> SurfAlerts { get; set; }

    }
}
