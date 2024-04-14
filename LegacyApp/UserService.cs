using LegacyApp.core.DAL.Repositories;
using LegacyApp.core.DAL.Services;
using LegacyApp.core.interfaces;
using LegacyApp.core.Validators.Clients;
using LegacyApp.core.Validators.Users;
using System;

namespace LegacyApp
{
    public class UserService
    {
        private IInputValidator _inputValidator;
        private IClientRepository _clientRepository;
        private ICreditLimitService _creditService;
        private IValidatorFactory _validatorFactory;
        private IUserCredit userCredit;

        public UserService()
        {
            _inputValidator = new InputValidator();
            _clientRepository = new ClientRepository();
            _creditService = new UserCreditService();
            _validatorFactory = new ValidatorFactory(userCredit);
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

            var clientValidator = _validatorFactory.Create(client);

            clientValidator.CreditCheck(ref user);

            if (!clientValidator.ValidateCredit(user))
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}
