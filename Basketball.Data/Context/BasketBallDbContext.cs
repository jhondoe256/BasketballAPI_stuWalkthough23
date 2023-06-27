using Basketball.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Basketball.Data.Context
{
    public class BasketBallDbContext : DbContext
    {
        public BasketBallDbContext(DbContextOptions<BasketBallDbContext> options):base(options){}

        //SEED DATA: 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Team>().HasData(
                new Team
                {
                    Id = 1,
                    Name = "Bulls"
                },
                 new Team
                {
                    Id = 2,
                    Name = "Knicks"
                }
            );

            modelBuilder.Entity<Position>().HasData(
                new Position
                {
                    Id= 1,
                    Name = "Point Guard"
                },
                 new Position
                {
                    Id= 2,
                    Name = "Center"
                },
                 new Position
                {
                    Id= 3,
                    Name = "Power Forward"
                },
                new Position()
                {
                     Id= 4,
                    Name = "Small Forward"
                }
            );

            modelBuilder.Entity<Player>().HasData(
                new Player()
                {
                    Id = 1,
                    FirstName = "Michael",
                    LastName = "Jordan",
                    PositionId = 1,
                    TeamId = 1,
                    JerseyNumber = 23
                },
                  new Player()
                {
                    Id = 2,
                    FirstName = "John",
                    LastName = "Starks",
                    TeamId = 2,
                    JerseyNumber =3
                }
            );
        }

        public DbSet<Team> Teams  { get; set; }
        public DbSet<Player> Players  { get; set; }
        public DbSet<Position> Positions  { get; set; }
        
    }
}