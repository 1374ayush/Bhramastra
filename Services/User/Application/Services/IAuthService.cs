using Domain.Models;

namespace Application.Services
{
    public interface IAuthService
    {
        public bool Login(UserModel model);
    }
}
