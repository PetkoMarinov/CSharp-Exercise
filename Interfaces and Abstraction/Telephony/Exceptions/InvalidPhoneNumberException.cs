using System;

namespace Telephony
{
    public class InvalidPhoneNumberException : Exception
    {
        private const string InvalidPhoneMsg = "Invalid number!";

        public InvalidPhoneNumberException() : base(InvalidPhoneMsg)
        {

        }
    }
}
