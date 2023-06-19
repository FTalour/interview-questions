using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInput
{
    public class TextInput
    {
        protected string _value = string.Empty;

        public virtual void Add(char c)
        {
            _value += c;
        }

        public string GetValue()
        {
            return _value;
        }
    }

    public class NumericInput : TextInput
    {
        public override void Add(char c)
        {
            if (char.IsDigit(c))
                _value += c;
        }
    }

    public class UserInput
    {
        public static void Main(string[] args)
        {
            TextInput input = new NumericInput();
            input.Add('1');
            input.Add('a');
            input.Add('0');
            Console.WriteLine(input.GetValue());
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }
    }
}
