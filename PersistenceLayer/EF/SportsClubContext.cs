using Microsoft.EntityFrameworkCore;
using SportsClubModel.Domain;

namespace PersistenceLayer.EF
{
    public class SportsClubContext : DbContext
    {
        public const string CONN_STRING = "Server = localhost; Database = SportsClub; User Id=SportsClub; Password=P@55w0rd; MultipleActiveResultSets = true";
        public SportsClubContext(DbContextOptions<SportsClubContext> options)
        : base(options)
        {}
        public DbSet<Court> Courts { get; set; }
        public DbSet<TennisCourt> TennisCourts { get; set; }
        public DbSet<PadelCourt> PadelCourts { get; set; }
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<ChallengeRegistration> ChallengeRegistrations{ get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Court>().ToTable("Courts")
                .HasDiscriminator<int>("CourtType")
                .HasValue<TennisCourt>((int)CourtType.TENNIS)
                .HasValue<PadelCourt>((int)CourtType.PADEL);

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