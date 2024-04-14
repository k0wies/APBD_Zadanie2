using System;
using LegacyApp.core.Validators.Clients;

namespace LegacyApp.core.interfaces
{
	public interface IValidatorFactory
	{
		public ClientValidator Create(Client client);
	}
}

