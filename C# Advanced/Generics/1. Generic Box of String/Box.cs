using System;
using System.Collections.Generic;
using System.Text;

namespace _1._Generic_Box_of_String
{
    class Box<T>
    {
        public Box(T value)
        {
            this.Value = value;
        }

        public T Value { get;}

        public override string ToString()
        {
            return $" {typeof(T)}: {Value}";
        }
    }
}
