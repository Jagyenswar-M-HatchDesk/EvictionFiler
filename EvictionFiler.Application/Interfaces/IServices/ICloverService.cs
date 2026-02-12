using EvictionFiler.Application.DTOs.TransactionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface ICloverService
    {
        Task<TransactionDto?> CreateChargeAsync(string token, int amount);
    }
}
