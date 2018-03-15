using Topic4.Models;
using Topic4.Services.Data;

namespace Topic4.Services.Business
{
    public class SecurityService
    {
        public bool Authenticate(UserModel user)
        {
            SecurityDAO service = new SecurityDAO();
            return service.FindByUser(user);    
        }
    }
}