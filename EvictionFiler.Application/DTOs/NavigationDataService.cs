using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.DTOs
{
    public class NavigationStateMessage
    {
        public string? SuccessMessage { get; private set; }
        public string? Page { get; private set; }
        public bool? Success { get; private set; }

        public void Set(string page, bool success, string message)
        {
            SuccessMessage = message;
            Success = success;
            Page = page;
        }

        public string? ConsumeMessage()
        {
            var msg = SuccessMessage;
            SuccessMessage = null; // auto-clear like TempData
            return msg;
        }
        public bool? ConsumeFlag()
        {
            bool? msg = Success;
            Success = null; // auto-clear like TempData
            return msg;
        }
    }

}
