using CLC2.Models;
using CLC2.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CLC2.Services.Business
{
    public class SecurityService
    {
        public bool Authenticate(User user)
        {
            SecurityDAO service = new SecurityDAO();
            return !InvalidParams(user) && service.FindByUser(user);
        }

        public bool Register(User user)
        {
            SecurityDAO service = new SecurityDAO();
            return !InvalidParams(user) && service.Create(user);
        }

        public bool UsernameExists(User user)
        {
            SecurityDAO service = new SecurityDAO();
            return InvalidParams(user) || service.UsernameFound(user);
        }

        private bool InvalidParams(User user)
        {
            return user.Username == null || user.Username.Trim().Equals("") || user.Password == null ||
                   user.Password.Trim().Equals("") || user.Username.Length < 1 || user.Password.Length < 1;
        }
    }
}