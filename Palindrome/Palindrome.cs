using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome
{
    /// <summary>
    /// A palindrome is a word that reads the same backward or forward.
    ///
    /// Write a function that checks if a given word is a palindrome.Character case should be ignored.
    ///
    /// For example, IsPalindrome("Deleveled") should return true as character case should be ignored, resulting in "deleveled", which is a palindrome since it reads the same backward and forward.
    /// </summary>
    class Palindrome
    {
        static bool IsPalindrome(string sentence)
        {
            string loweredWord = sentence.Replace(" ", string.Empty).ToLower();
            for (int i = 0; i < sentence.Length / 2; i++)
            {
                if (loweredWord[i] != loweredWord[sentence.Length-i-1])
                    return false;
            }

            return true;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Palindrome.IsPalindrome("Deleveled"));
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }
    }
}
