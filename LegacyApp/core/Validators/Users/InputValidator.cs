﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegacyApp.core.interfaces;

namespace LegacyApp.core.Validators.Users
{
    internal class InputValidator : IInputValidator
    {

        public bool ValidateAge(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;

            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

            if (age < 21)
            {
                return false;
            }

            return true;
        }

        public bool ValidateEmail(string email)
        {
            if (!email.Contains("@") && !email.Contains("."))
            {
                return false;
            }

            return true;
        }

        public bool ValidateName(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return false;
            }
            return true;
        }
    }
}
