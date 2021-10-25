using System;

namespace Telephony
{
    public class InvalidUrlException : Exception
    {
        private const string InvalidUrlMsg = "Invalid URL!";

        public InvalidUrlException() : base(InvalidUrlMsg)
        {

        }
    }
}
