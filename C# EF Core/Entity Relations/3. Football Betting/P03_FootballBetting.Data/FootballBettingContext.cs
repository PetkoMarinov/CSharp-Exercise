using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext(DbContextOptions options) : base(options)
        {
        }

        public FootballBettingContext()
        {
        }

        public DbSet<Bet> Bets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(@"Server=BG190101\SQLEXPRESS;Database=FootballBetting;
                                        Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Team>()
                .HasOne(c => c.PrimaryKitColor)
                .WithMany(c => c.PrimaryKitTeams)
                .HasForeignKey(fk => fk.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Team>()
                .HasOne(c => c.SecondaryKitColor)
                .WithMany(c => c.SecondaryKitTeams)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
                .HasOne(t => t.HomeTeam)
                .WithMany(t => t.HomeGames)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
                .HasOne(t => t.AwayTeam)
                .WithMany(t => t.AwayGames)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PlayerStatistic>().HasKey(pk => new { pk.GameId, pk.PlayerId });
        }

        


    }
}
