using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersistenceLayer.EF.IdentityModel;
using SportsClubModel.Domain;

namespace PersistenceLayer.EF
{
    public class SportsClubContext : IdentityDbContext<ApplicationUser>
    {
        public const string CONN_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SportsClub;MultipleActiveResultSets = true";
        public SportsClubContext(DbContextOptions<SportsClubContext> options)
        : base(options)
        {}
        public DbSet<Court> Courts { get; set; }
        public DbSet<TennisCourt> TennisCourts { get; set; }
        public DbSet<SquashCourt> SquashCourts { get; set; }
        public DbSet<SoccerCourt> SoccerCourts { get; set; }
        public DbSet<PadelCourt> PadelCourts { get; set; }
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<ChallengeRegistration> ChallengeRegistrations{ get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Court>().ToTable("Courts")
                .HasDiscriminator<int>("CourtType")
                .HasValue<TennisCourt>((int)CourtType.Tennis)
                .HasValue<SquashCourt>((int)CourtType.Squash)
                .HasValue<SoccerCourt>((int)CourtType.Soccer)
                .HasValue<PadelCourt>((int)CourtType.Padel);

            modelBuilder.Entity<ChallengeRegistration>()
            .HasKey(cr => cr.Id);
            modelBuilder.Entity<ChallengeRegistration>()
                .HasOne(cr => cr.Member)
                .WithMany(m => m.ChallengeRegistrations)
                .HasForeignKey(cr => cr.MemberId);
            modelBuilder.Entity<ChallengeRegistration>()
                .HasOne(cr => cr.Challenge)
                .WithMany(ch => ch.ChallengeRegistrations)
                .HasForeignKey(cr => cr.ChallengeId);
        }

        public static SportsClubContext CreateContext(string connectionString
           = SportsClubContext.CONN_STRING)
        {
            var optionBuilder = new DbContextOptionsBuilder<SportsClubContext>();
            optionBuilder.UseSqlServer(connectionString);
            return new SportsClubContext(optionBuilder.Options);
        }


    }
}