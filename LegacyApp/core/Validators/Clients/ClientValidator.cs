using System;
using LegacyApp.core.interfaces;

namespace LegacyApp.core.Validators.Clients
{
	public abstract class ClientValidator
	{
        protected IUserCredit _userCredit;

        public ClientValidator(IUserCredit userCredit)
		{
			_userCredit = userCredit;
		}

		public abstract void CreditCheck(ref User user);

        internal bool ValidateCredit(User user)
        {
            if(user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }
            return true;
        }
    }
}

