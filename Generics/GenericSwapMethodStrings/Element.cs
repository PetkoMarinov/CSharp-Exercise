using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodStrings
{
    class Element<T>
    {
        public Element(List<T> elementsList)
        {
            this.Elements = elementsList;
        }

        public List<T> Elements { get; }
       
        public void  Swap (List<T> list, int index1, int index2)
        {
            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (T element in Elements)
            {
                sb.AppendLine($"{element.GetType()}: {element}");
            }

            return sb.ToString().Trim();
        }
    }
}
