using System.Threading.Tasks;

namespace Course.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);
    }
}
