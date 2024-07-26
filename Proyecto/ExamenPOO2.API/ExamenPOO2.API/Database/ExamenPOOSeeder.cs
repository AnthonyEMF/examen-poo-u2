using Newtonsoft.Json;

namespace ExamenPOO2.API.Database
{
	public class ExamenPOOSeeder
	{
		public static async Task LoadDataAsync(ExamenPOOContext context, ILoggerFactory loggerFactory)
		{
			try
			{
				//await LoadCategoriesAsync(context, loggerFactory);
			}
			catch (Exception e)
			{
				var logger = loggerFactory.CreateLogger<ExamenPOOSeeder>();
				logger.LogError(e, "Error inicializando la data del API");
			}
		}

		//public static async Task LoadCategoriesAsync(ExamenPOOContext context, ILoggerFactory loggerFactory)
		//{
		//	try
		//	{
		//		var jsonFilePatch = "SeedData/categories.json";
		//		var jsonContent = await File.ReadAllTextAsync(jsonFilePatch);
		//		var categories = JsonConvert.DeserializeObject<List<CategoryEntity>>(jsonContent);

		//		if (!await context.Categories.AnyAsync())
		//		{
		//			//for (int i = 0; i < categories.Count; i++)
		//			//{
		//			//	categories[i].CreatedBy = "1fa61610-c8a3-4a50-93cf-35bf5232656c";
		//			//	categories[i].CreatedDate = DateTime.Now;
		//			//	categories[i].UpdatedBy = "1fa61610-c8a3-4a50-93cf-35bf5232656c";
		//			//	categories[i].UpdatedDate = DateTime.Now;
		//			//}
		//			context.AddRange(categories);
		//			await context.SaveChangesAsync();
		//		}
		//	}
		//	catch (Exception e)
		//	{
		//		var logger = loggerFactory.CreateLogger<ExamenPOOSeeder>();
		//		logger.LogError(e, "Error al ejecutar el Seed de Categorias");
		//	}
		//}
	}
}
