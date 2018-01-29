using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MSWA_Milestone2.Models;
using MSWA_Milestone2.Services.Data;

namespace MSWA_Milestone2.Services.Business
{
    public class SecurityService
    {
        public bool Authenticate(User user)
        {
            SecurityDAO service = new SecurityDAO();
            return service.FindByUser(user);
        }
    }
}