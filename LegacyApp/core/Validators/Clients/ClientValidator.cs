using System;
using LegacyApp.core.interfaces;

namespace LegacyApp.core.Validators.Clients
{
	public abstract class ClientValidator
	{
		public ClientValidator(IUserCredit userCredit)
		{
		}

		public abstract void CreditCheck(ref User user);
    }
}

