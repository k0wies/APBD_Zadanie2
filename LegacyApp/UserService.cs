using LegacyApp.core.DAL.Repositories;
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
        private ICreditLimitService _creditService;


        public UserService()
        {
            _inputValidator = new InputValidator();
            _clientRepository = new ClientRepository();
            _creditService = new UserCreditService();
        }

        public UserService(IInputValidator inputValidator, IClientRepository clientRepository, ICreditLimitService creditService)
        {
            _inputValidator = inputValidator;
            _clientRepository = clientRepository;
            _creditService = creditService;
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            //Input Validation
            if(!_inputValidator.ValidateName(firstName, lastName))
            {
                return false;
            };

            if (!_inputValidator.ValidateEmail(email))
            {
                return false;
            }

            if (!_inputValidator.ValidateAge(dateOfBirth))
            {
                return false;
            }

            var client = _clientRepository.GetById(clientId);

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
                int creditLimit = _creditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                creditLimit = creditLimit * 2;
                user.CreditLimit = creditLimit;
                
            }
            else
            {
                user.HasCreditLimit = true;
                int creditLimit = _creditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                user.CreditLimit = creditLimit;
            }

            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}
