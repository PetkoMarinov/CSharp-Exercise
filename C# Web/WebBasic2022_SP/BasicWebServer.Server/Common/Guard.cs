using System;

namespace BasicWebServer.Server.Common
{
    public static class Guard
    {
        //When creating a software, which relies on user input, it is a good idea to add some checks of input data.
        //That’s why we will check every time when we create a class if there are any properties with a NULL value,
        //as they may be problematic.

        //will accept a value and optionally a name. If the value is null, an exception will be thrown. 
        public static void AgainstNull(object value, string name = null) 
        {
            if (value == null)
            {
                name ??= "Value";

                throw new ArgumentException($"{name} cannot be null.");
            }
        }
    }
}
