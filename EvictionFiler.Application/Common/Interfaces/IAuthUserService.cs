using EvictionFiler.Application.Common.Models;

namespace EvictionFiler.Application.Common.Interfaces
{
    public interface ILoggedInUserService
    {
        Task<LoggedInUser> GetAsync();
    }
}
