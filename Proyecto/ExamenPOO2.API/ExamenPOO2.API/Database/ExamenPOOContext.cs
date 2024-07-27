using ExamenPOO2.API.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamenPOO2.API.Database
{
	public class ExamenPOOContext : DbContext
	{
        public ExamenPOOContext(DbContextOptions options) : base(options)
        {
            
        }

		public DbSet<LoanEntity> Loans { get; set; }
		public DbSet<ClientEntity> Clients { get; set; }
		public DbSet<AmortizationEntity> Amortizations { get; set; }
	}
}
