using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyApp.core.interfaces
{
    public interface IInputValidator
    {
        public bool ValidateEmail(string email);
        public bool ValidateName(string firstName, string lastName);
        public bool ValidateAge(DateTime dateOfBirth);

    }
}
