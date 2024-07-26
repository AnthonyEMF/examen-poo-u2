using Microsoft.EntityFrameworkCore;

namespace ExamenPOO2.API.Database
{
	public class ExamenPOOContext : DbContext
	{
        public ExamenPOOContext(DbContextOptions options) : base(options)
        {
            
        }

		//public DbSet<CategoryEntity> Categories { get; set; }
	}
}
