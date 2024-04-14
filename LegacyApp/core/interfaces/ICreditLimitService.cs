using System;

namespace LegacyApp.core.interfaces
{
	public interface ICreditLimitService
	{
		int GetCreditLimit(string lastName, DateTime dateOfBirth);
	}
}

