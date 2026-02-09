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
