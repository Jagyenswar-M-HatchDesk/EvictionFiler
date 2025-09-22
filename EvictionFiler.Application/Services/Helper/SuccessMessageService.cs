using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Application.Services.Helper
{
    public class SuccessMessageService
    {
        public event Action<string> OnMessageShow;

        public void ShowMessage(string message)
        {
            OnMessageShow?.Invoke(message);
        }
    }
}
