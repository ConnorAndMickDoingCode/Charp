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
using CLC.Services.Utility;

namespace CLC.Services.Business
{
    public class SecurityService
    {
        private readonly ILogger _logger = new TheLogger();

       
        /**
         * Logs a user in
         */
        public bool Authenticate(User user)
        {
            _logger.Info("SecurityService::Authenticate -- Entering");
            // if user object is valid and is found: true
            SecurityDAO service = new SecurityDAO();
            _logger.Info("SecurityService::Authenticate -- Exiting");
            return !InvalidParams(user) && service.FindByUser(user);
        }

        /**
         * Register a user 
         * return success
         */
        public bool Register(User user)
        {
            _logger.Info("SecurityService::Register -- Entering");
            // if user object is valid and username is unique: true
            SecurityDAO service = new SecurityDAO();
            _logger.Info("SecurityService::Regiser -- Exiting");
            return !InvalidParams(user) && service.Create(user);
        }

        /**
         * Checks if a username exists
         */
        public bool UsernameExists(User user)
        {
            _logger.Info("SecurityService::UsernameExists -- Entering");
            // if user object is valid and username is not found: false
            SecurityDAO service = new SecurityDAO();
            _logger.Info("SecurityService::UsernameExist -- Exiting");
            return InvalidParams(user) || service.UsernameFound(user);
        }

        /**
         * Validate User object properties
         */
        private bool InvalidParams(User user)
        {
            _logger.Info("SecurityService::InvalidParams -- Entering");
            // check if params are valid
            _logger.Info("SecurityService::InvalidParams -- Exiting");
            return user.Username == null || user.Username.Trim().Equals("") || user.Password == null ||
                   user.Password.Trim().Equals("") || user.Username.Length < 1 || user.Password.Length < 1;
        }
    }
}