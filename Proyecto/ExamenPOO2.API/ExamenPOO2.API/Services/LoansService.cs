using AutoMapper;
using ExamenPOO2.API.Database;
using ExamenPOO2.API.Database.Entities;
using ExamenPOO2.API.Dtos.Amortization;
using ExamenPOO2.API.Dtos.Common;
using ExamenPOO2.API.Dtos.Loan;
using ExamenPOO2.API.Services.Interfaces;

namespace ExamenPOO2.API.Services
{
	public class LoansService : ILoansService
	{
		private readonly ExamenPOOContext _context;
		private readonly IMapper _mapper;

		public LoansService(ExamenPOOContext context, IMapper mapper)
        {
			this._context = context;
			this._mapper = mapper;
		}

		// Funcion para POST, generar un un plan amortizacion
		public async Task<ResponseDto<LoanDto>> CreateAmortizationPlanAsync(LoanCreateDto dto)
		{
			var loanEntity = _mapper.Map<LoanEntity>(dto);

			// Realizacion de calculos y logica mediante AmortizationEntity

			//var amortizationDto = _mapper.Map<AmortizationDto>(amortizationEntity);

			return new ResponseDto<LoanDto>
			{
				StatusCode = 201,
				Status = true,
				Message = "Loan and amortization plan successfully created.",
				//Data = amortizationDto
			};
		}

		// Funcion para GET con el ClientId, mostrar informacion del cliente y el plan de amortizacion
		public async Task<ResponseDto<LoanDto>> GetAmortizationPlanByIdAsync(Guid id)
		{
			// Obtener toda la informacion del Prestamo y Plan de Amortization 

			return new ResponseDto<LoanDto>
			{
				StatusCode = 201,
				Status = true,
				Message = "Informacion obtenida correctamente.",
				//Data = amortizationDto
			};
		}
	}
}
