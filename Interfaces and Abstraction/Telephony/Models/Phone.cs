using System;
using System.Linq;

namespace Telephony
{
    public abstract class Phone : ICall
    {
        public virtual string Call(string phoneNumber)
        {
            if (!phoneNumber.All(num => char.IsDigit(num)))
            {
                throw new InvalidPhoneNumberException();
            }
            return "";
        }
    }
}
