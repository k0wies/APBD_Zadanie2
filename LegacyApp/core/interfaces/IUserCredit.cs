using System;
namespace LegacyApp.core.interfaces
{
    public interface IUserCredit
    {
        int GetCreditLimit(string lastName, DateTime dateOfBirth);
    }
}

