using System;
using LegacyApp.core.interfaces;

namespace LegacyApp.core.Validators.Clients
{
	public class OtherClientValidator : ClientValidator
	{
		public OtherClientValidator(IUserCredit userCredit) : base(userCredit)
		{
		}

        public override void CreditCheck(ref User user)
        {
            if (_userCredit != null)
            {
                user.HasCreditLimit = true;
                int creditLimit = _userCredit.GetCreditLimit(user.LastName, user.DateOfBirth);
                user.CreditLimit = creditLimit;
            }
        }
    }
}

