using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurfProject.Model
{
    public class MemberDetailsContext : DbContext
    {


        public MemberDetailsContext(DbContextOptions<MemberDetailsContext> options)
            : base(options)
        { }


        public DbSet<Member> Members { get; set; }

        public DbSet<SurfProfile> SurfProfiles { get; set; }

        public DbSet<RootObject> RootObjects { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Components>(table =>
            {
                // Similar to the table variable above, this allows us to get
                // an address variable that we can use to map the complex
                // type's properties
                table.OwnsOne(
                    x => x.Combined,
                    components =>
                    {
                        components.Property(x => x.CompassDirection).HasColumnName("CompassDirection1");
                        components.Property(x => x.Direction).HasColumnName("Direction1");
                        components.Property(x => x.Height).HasColumnName("Height1");
                        components.Property(x => x.Period).HasColumnName("Period1");

                    });

                table.OwnsOne(
              x => x.Primary,
              components =>
              {
                  components.Property(x => x.CompassDirection).HasColumnName("CompassDirection2");
                  components.Property(x => x.Direction).HasColumnName("Direction2");
                  components.Property(x => x.Height).HasColumnName("Height2");
                  components.Property(x => x.Period).HasColumnName("Period2");
              });


                table.OwnsOne(
              x => x.Secondary,
              components =>
              {
                  components.Property(x => x.CompassDirection).HasColumnName("CompassDirection3");
                  components.Property(x => x.Direction).HasColumnName("Direction3");
                  components.Property(x => x.Height).HasColumnName("Height3");
                  components.Property(x => x.Period).HasColumnName("Period3");
              });


                table.OwnsOne(
              x => x.Tertiary,
              components =>
              {
                  components.Property(x => x.CompassDirection).HasColumnName("CompassDirection4");
                  components.Property(x => x.Direction).HasColumnName("Direction4");
                  components.Property(x => x.Height).HasColumnName("Height4");
                  components.Property(x => x.Period).HasColumnName("Period4");
              });

            });
        }

    }
}
