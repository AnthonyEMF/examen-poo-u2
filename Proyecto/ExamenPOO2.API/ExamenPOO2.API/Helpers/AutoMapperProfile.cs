using AutoMapper;
using ExamenPOO2.API.Database.Entities;
using ExamenPOO2.API.Dtos.Client;
using ExamenPOO2.API.Dtos.Loan;

namespace ExamenPOO2.API.Helpers
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			MapsForLoans();
			MapsForClients();
		}

		private void MapsForLoans()
		{
			CreateMap<LoanEntity, LoanDto>();
			CreateMap<LoanCreateDto, LoanEntity>();
			CreateMap<LoanEditDto, LoanEntity>();
		}

		private void MapsForClients()
		{
			CreateMap<ClientEntity, ClientDto>();
			CreateMap<ClientCreateDto, ClientEntity>();
			CreateMap<ClientEditDto, ClientEntity>();
		}
	}
}
