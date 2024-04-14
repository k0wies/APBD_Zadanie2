using System;
using LegacyApp.core.interfaces;

namespace LegacyApp.core.Validators.Clients
{
	public class ImportantClientValidator : ClientValidator
	{
		public ImportantClientValidator(IUserCredit userCredit) : base(userCredit)
        {
		}

        public override void CreditCheck(ref User user)
        {
            user.HasCreditLimit = true;
        }
    }
}

