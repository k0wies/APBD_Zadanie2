using System;
using LegacyApp.core.interfaces;

namespace LegacyApp.core.Validators.Clients
{
	public class VeryImportantClientValidator : ClientValidator
	{
		public VeryImportantClientValidator(IUserCredit userCredit) : base(userCredit)
		{
		}

		public override void CreditCheck(ref User user)
		{
			user.HasCreditLimit = false;
		}

	}
}

