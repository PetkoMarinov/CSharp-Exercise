namespace Telephony
{
    public class StationaryPhone : Phone
    {
        public override string Call(string phoneNumber)
        {
            base.Call(phoneNumber);
            return $"Dialing... {phoneNumber}";
        }
    }
}
