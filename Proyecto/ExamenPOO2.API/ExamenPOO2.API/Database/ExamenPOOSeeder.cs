using ExamenPOO2.API.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ExamenPOO2.API.Database
{
	public class ExamenPOOSeeder
	{
		public static async Task LoadDataAsync(ExamenPOOContext context, ILoggerFactory loggerFactory)
		{
			try
			{
				await LoadLoansAsync(context, loggerFactory);
				await LoadClientsAsync(context, loggerFactory);
				await LoadAmortizationsAsync(context, loggerFactory);
			}
			catch (Exception e)
			{
				var logger = loggerFactory.CreateLogger<ExamenPOOSeeder>();
				logger.LogError(e, "Error inicializando la data del API");
			}
		}

		public static async Task LoadLoansAsync(ExamenPOOContext context, ILoggerFactory loggerFactory)
		{
			try
			{
				var jsonFilePatch = "SeedData/loans.json";
				var jsonContent = await File.ReadAllTextAsync(jsonFilePatch);
				var loans = JsonConvert.DeserializeObject<List<LoanEntity>>(jsonContent);

				if (!await context.Loans.AnyAsync())
				{
					context.AddRange(loans);
					await context.SaveChangesAsync();
				}
			}
			catch (Exception e)
			{
				var logger = loggerFactory.CreateLogger<ExamenPOOSeeder>();
				logger.LogError(e, "Error al ejecutar el Seed de Prestamos");
			}
		}

		public static async Task LoadClientsAsync(ExamenPOOContext context, ILoggerFactory loggerFactory)
		{
			try
			{
				var jsonFilePatch = "SeedData/clients.json";
				var jsonContent = await File.ReadAllTextAsync(jsonFilePatch);
				var clients = JsonConvert.DeserializeObject<List<ClientEntity>>(jsonContent);

				if (!await context.Clients.AnyAsync())
				{
					context.AddRange(clients);
					await context.SaveChangesAsync();
				}
			}
			catch (Exception e)
			{
				var logger = loggerFactory.CreateLogger<ExamenPOOSeeder>();
				logger.LogError(e, "Error al ejecutar el Seed de Clientes");
			}
		}

		public static async Task LoadAmortizationsAsync(ExamenPOOContext context, ILoggerFactory loggerFactory)
		{
			try
			{
				var jsonFilePatch = "SeedData/amortizations.json";
				var jsonContent = await File.ReadAllTextAsync(jsonFilePatch);
				var amortizations = JsonConvert.DeserializeObject<List<AmortizationEntity>>(jsonContent);

				if (!await context.Amortizations.AnyAsync())
				{
					context.AddRange(amortizations);
					await context.SaveChangesAsync();
				}
			}
			catch (Exception e)
			{
				var logger = loggerFactory.CreateLogger<ExamenPOOSeeder>();
				logger.LogError(e, "Error al ejecutar el Seed de Amortizaciones");
			}
		}
	}
}
