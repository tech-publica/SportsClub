 using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PersistenceLayer.EF
{
    public class SportsClubContextFactory : 
              IDesignTimeDbContextFactory<SportsClubContext>
    {
        public SportsClubContext CreateDbContext(string[] args)
        {
            
             var optionsBuilder = new DbContextOptionsBuilder<SportsClubContext>();
            optionsBuilder.UseSqlServer(SportsClubContext.CONN_STRING);

            return new SportsClubContext(optionsBuilder.Options);
        }
    }
    
}