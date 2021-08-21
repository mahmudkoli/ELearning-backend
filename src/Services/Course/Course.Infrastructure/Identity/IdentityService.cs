using Course.Application.Common.Interfaces;

namespace Course.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        public IdentityService()
        {

        }

        public async Task<string> GetUserNameAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
