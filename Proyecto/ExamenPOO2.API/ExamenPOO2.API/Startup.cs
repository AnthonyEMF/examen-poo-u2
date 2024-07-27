using ExamenPOO2.API.Database;
using ExamenPOO2.API.Helpers;
using ExamenPOO2.API.Services;
using ExamenPOO2.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExamenPOO2.API
{
	public class Startup
	{
		private IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		// Services
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();

			// Add DbContext
			services.AddDbContext<ExamenPOOContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			// Add Custom Services
			services.AddTransient<ILoansService, LoansService>();

			// Add AutoMapper
			services.AddAutoMapper(typeof(AutoMapperProfile));
		}

		// Middlewords
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
