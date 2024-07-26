using AutoMapper;

namespace ExamenPOO2.API.Helpers
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			MapsForCategories();
		}

		private void MapsForCategories()
		{
			//CreateMap<CategoryEntity, CategoryDto>();
			//CreateMap<CategoryCreateDto, CategoryEntity>();
			//CreateMap<CategoryEditDto, CategoryEntity>();
		}
	}
}
