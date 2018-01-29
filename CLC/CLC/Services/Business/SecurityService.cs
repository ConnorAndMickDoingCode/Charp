﻿/*
 version 0.2
 Connor, Mick
 CST-256 
 January 28, 2018 
 This assignment was completed in collaboration with Connor Low, Mick Torres. 
 We used source code from the following websites to complete this assignment: N/ A 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CLC.Models;
using CLC.Services.Data;

namespace CLC.Services.Business
{
    public class SecurityService
    {
        public bool Authenticate(User user)
        {
            SecurityDAO service = new SecurityDAO();
            return service.FindByUser(user);
        }

        public bool Register(User user)
        {
            SecurityDAO service = new SecurityDAO();
            return service.Create(user);
        }

        public bool CheckForUsername(User user)
        {
            SecurityDAO service = new SecurityDAO();
            return service.CheckUsername(user);
        }
    }
}