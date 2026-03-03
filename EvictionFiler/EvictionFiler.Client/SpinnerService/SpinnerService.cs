namespace EvictionFiler.Client.SpinnerService
{
    public class SpinnerService
    {
        public event Action? OnShow;
        public event Action? OnHide;
        public string? spinnerMessage;
        public void Show() => OnShow?.Invoke();
        public void Hide() => OnHide?.Invoke();
    }
}
