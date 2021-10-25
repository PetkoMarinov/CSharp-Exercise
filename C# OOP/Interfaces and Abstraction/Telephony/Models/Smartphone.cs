using System.Linq;

namespace Telephony
{
    public class Smartphone : Phone, IBrowse
    {
        public string Browse(string url)
        {
            if (url.Any(x=>char.IsDigit(x)))
            {
                throw new InvalidUrlException();
            }
            return $"Browsing: {url}!";
        }

        public override string Call(string phoneNumber)
        {
            base.Call(phoneNumber);
            return $"Calling... {phoneNumber}";
        }

    }
}
