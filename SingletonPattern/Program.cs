using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public sealed class Singleton
    {
        private static Singleton instance = new Singleton();
        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Singleton()
        {
        }
        private Singleton() { }
        public static Singleton Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
