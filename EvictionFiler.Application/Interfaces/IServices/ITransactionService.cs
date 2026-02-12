using EvictionFiler.Application.DTOs.TransactionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface ITransactionService
    {
        Task<bool> AddTransaction(TransactionDto dto);
    }
}
