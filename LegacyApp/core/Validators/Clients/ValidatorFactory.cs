using System;
using LegacyApp.core.interfaces;

namespace LegacyApp.core.Validators.Clients
{
	public class ValidatorFactory : IValidatorFactory
	{
		public IUserCredit _userCredit { get; set; }

		public ValidatorFactory(IUserCredit userCredit)
		{
			_userCredit = userCredit;
		}

        public ClientValidator Create(Client client)
        {
			try
			{
                return (ClientValidator)Activator.CreateInstance(Type.GetType($"LegacyApp.Core.Validators.Clients.{client.Name}Validator"), new object[] { _userCredit });
			}
			catch
			{
				return new OtherClientValidator(_userCredit);
			}
        }
    }
}

