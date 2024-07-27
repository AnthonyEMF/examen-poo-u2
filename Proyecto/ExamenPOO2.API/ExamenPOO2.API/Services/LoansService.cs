using AutoMapper;
using ExamenPOO2.API.Database;
using ExamenPOO2.API.Database.Entities;
using ExamenPOO2.API.Dtos.Amortization;
using ExamenPOO2.API.Dtos.Common;
using ExamenPOO2.API.Dtos.Loan;
using ExamenPOO2.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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
			var existingClient = await _context.Clients.SingleOrDefaultAsync(c => c.IdentityNumber == dto.IdentityNumber);
			if (existingClient is not null)
			{
				return new ResponseDto<LoanDto>
				{
					StatusCode = 400,
					Status = false,
					Message = "Error: El Identify Number ya existe"
				};
			}

			// Crear Cliente
			var clientEntity = new ClientEntity
			{
				Name = dto.Name,
				IdentityNumber = dto.IdentityNumber
			};

			// Crear Prestamo
			var loanEntity = new LoanEntity
			{
				LoanAmount = dto.LoanAmount,
				CommissionRate = dto.CommissionRate,
				InterestRate = dto.InterestRate,
				Term = dto.Term,
				DisbursementDate = dto.DisbursementDate,
				FirstPaymentDate = dto.FirstPaymentDate,
				Client = clientEntity
			};

			var amortization = CalculateAmortizationPlan(loanEntity);

			loanEntity.AmortizationPlan = amortization;
			await _context.Loans.AddAsync(loanEntity);
			await _context.Amortizations.AddRangeAsync(amortization);
			await _context.Clients.AddAsync(clientEntity);
;			await _context.SaveChangesAsync();

			var loanResponse = new LoanDto
			{
				Message = "Loan and amortization plan successfully created",
				AmortizationPlan = amortization.Select(a => new AmortizationDto
				{
					InstallmentNumber = a.InstallmentNumber,
					PaymentDate = a.PaymentDate,
					Days = a.Days,
					Interest = a.Interest,
					Principal = a.Principal,
					LevelPaymentWithoutSVSD = a.LevelPaymentWithoutSVSD,
					LevelPaymentWithSVSD = a.LevelPaymentWithSVSD,
					PrincipalBalance = a.PrincipalBalance
				}).ToList()
			};

			return new ResponseDto<LoanDto>
			{
				StatusCode = 201,
				Status = true,
				Message = "Registro creado correctamente",
				Data = loanResponse
			};
		}

		// Realizacion de calculos y logica mediante AmortizationEntity
		private List<AmortizationEntity> CalculateAmortizationPlan(LoanEntity loan)
		{
			var plan = new List<AmortizationEntity>();

			var commission = loan.LoanAmount * (loan.CommissionRate/100);

			var principalBalance = loan.LoanAmount + commission;

			var interestRate = loan.InterestRate/100/12;

			var levelPaymentWithoutSVSD = principalBalance * interestRate / (1-Math.Pow(1+interestRate,-loan.Term));

			// Estableci 30 porque es el promedio de dias en un mes
			const int days = 30;

			for (int i=1; i<=loan.Term; i++)
			{
				var interest = principalBalance * interestRate;
				var principal = levelPaymentWithoutSVSD - interest;

				var SVSD = principalBalance * 0.0015;
				var levelPaymentWithSVSD = levelPaymentWithoutSVSD + SVSD;

				principalBalance -= principal;

				var amortization = new AmortizationEntity
				{
					InstallmentNumber = i,
					PaymentDate = loan.FirstPaymentDate.AddMonths(i-1),
					Days = days,
					Interest = interest,
					Principal = principal,
					LevelPaymentWithoutSVSD = levelPaymentWithoutSVSD,
					LevelPaymentWithSVSD = levelPaymentWithSVSD,
					PrincipalBalance = principalBalance
				};
				plan.Add(amortization);
			}
			return plan;
		}

		// Funcion para GET con el ClientId, mostrar informacion del cliente y el plan de amortizacion
		public async Task<ResponseDto<ClientLoanResponseDto>> GetAmortizationPlanByIdAsync(Guid id)
		{
			// Obtener toda la informacion del Prestamo y Plan de Amortization

			var client = await _context.Clients.Include(c => c.Loans).ThenInclude(l => l.AmortizationPlan).SingleOrDefaultAsync(c => c.Id == id);

			if (client is null)
			{
				return new ResponseDto<ClientLoanResponseDto>
				{
					StatusCode = 404,
					Status = false,
					Message = "Registro no encontrado"
				};
			}

			var loan = client.Loans.FirstOrDefault();
			var amortizationPlan = loan?.AmortizationPlan.Select(a => new AmortizationDto
			{
				InstallmentNumber = a.InstallmentNumber,
				PaymentDate = a.PaymentDate,
				Days = a.Days,
				Interest = a.Interest,
				Principal = a.Principal,
				LevelPaymentWithoutSVSD = a.LevelPaymentWithoutSVSD,
				LevelPaymentWithSVSD = a.LevelPaymentWithSVSD,
				PrincipalBalance = a.PrincipalBalance
			}).ToList();

			var clientLoanResponse = new ClientLoanResponseDto
			{
				ClientId = client.Id,
				Name = client.Name,
				IdentityNumber = client.IdentityNumber,
				LoanAmount = loan.LoanAmount,
				AmortizationPlan = amortizationPlan
			};

			return new ResponseDto<ClientLoanResponseDto>
			{
				StatusCode = 200,
				Status = true,
				Message = "Registro encontrado",
				Data = clientLoanResponse
			};
		}

	}
}
