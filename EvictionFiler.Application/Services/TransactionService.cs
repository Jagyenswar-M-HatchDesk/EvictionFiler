using EvictionFiler.Application.DTOs.TransactionDtos;
using EvictionFiler.Application.Interfaces.IRepository;
using EvictionFiler.Application.Interfaces.IServices;
using EvictionFiler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepo;
        private readonly IUnitOfWork _unitOfWork;
        public TransactionService(ITransactionRepository transactionRepo, IUnitOfWork unitOfWork)
        {
            _transactionRepo = transactionRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddTransaction(TransactionDto dto)
        {
            var transaction = new Transactions
            {
                Id = dto.Id,
                ReferenceNumber = dto.ReferenceNumber,
                Amount = dto.Amount,
                AuthorizationCode = dto.AuthorizationCode,
                Captured = dto.Captured,
                Status = dto.Status,
                CloverChargeId = dto.CloverChargeId,
                CreatedUtc = dto.CreatedUtc,
                Paid = dto.Paid,
                Currency = dto.Currency,
                CreatedBy = dto.CreatedBy,
            };
             await _transactionRepo.AddAsync(transaction);
            var result = await _unitOfWork.SaveChangesAsync();
            if (result > 0) return true;

            return false;
        }
    }
}
