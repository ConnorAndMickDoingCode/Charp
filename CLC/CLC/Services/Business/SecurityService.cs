/*
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
        /**
         * Logs a user in
         */
        public bool Authenticate(User user)
        {
            // if user object is valid and is found: true
            SecurityDAO service = new SecurityDAO();
            return !InvalidParams(user) && service.FindByUser(user);
        }

        /**
         * Register a user 
         * return success
         */
        public bool Register(User user)
        {
            // if user object is valid and username is unique: true
            SecurityDAO service = new SecurityDAO();
            return !InvalidParams(user) && service.Create(user);
        }

        /**
         * Checks if a username exists
         */
        public bool UsernameExists(User user)
        {
            // if user object is valid and username is not found: false
            SecurityDAO service = new SecurityDAO();
            return InvalidParams(user) || service.UsernameFound(user);
        }

        /**
         * Validate User object properties
         */
        private bool InvalidParams(User user)
        {
            // check if params are valid
            return user.Username == null || user.Username.Trim().Equals("") || user.Password == null ||
                   user.Password.Trim().Equals("") || user.Username.Length < 1 || user.Password.Length < 1;
        }
    }
}