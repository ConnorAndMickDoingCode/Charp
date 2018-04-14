using ICA_10.Models;
using ICA_10.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICA_10.Services.Business
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