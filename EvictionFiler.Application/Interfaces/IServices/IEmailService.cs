using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Interfaces.IServices
{
    public interface IEmailService
    {
        Task SendFirmEnrollEmailAsync(string toEmail, string userName, string firmName, string password);
    }
}
