﻿using LegacyApp.core.DAL.Repositories;
using LegacyApp.core.DAL.Services;
using LegacyApp.core.interfaces;
using LegacyApp.core.Validators.Users;
using System;

namespace LegacyApp
{
    public class UserService
    {
        private IInputValidator _inputValidator;
        private IClientRepository _clientRepository;

        public UserService()
        {
            _inputValidator = new InputValidator();
            _clientRepository = new ClientRepository();
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            //SRP
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return false;
            }

            if (!email.Contains("@") && !email.Contains("."))
            {
                return false;
            }

            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

            if (age < 21)
            {
                return false;
            }

            //DIP
            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            //DIP OCP
            if (client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            else if (client.Type == "ImportantClient")
            {
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    creditLimit = creditLimit * 2;
                    user.CreditLimit = creditLimit;
                }
            }
            else
            {
                user.HasCreditLimit = true;
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    user.CreditLimit = creditLimit;
                }
            }

            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }

        public bool ValidateEmail(string email)
        {
            if (!email.Contains("@") && !email.Contains("."))
            {
                return false;
            }

            return true;
        }
    }
}