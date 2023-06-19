using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTimer
{
    class Program
    {
        private static void WaitOrPressKey(TimeSpan timeout)
        {
            ManualResetEvent allDone = new ManualResetEvent(false);

            Console.WriteLine($"Press Enter to continue ({timeout.TotalSeconds} secondes)");

            System.Threading.Tasks.Task taskWait = System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                allDone.WaitOne(timeout);
            });

            System.Threading.Tasks.Task taskRead = System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                Console.Read();
                allDone.Set();
            });

            taskWait.Wait();
        }

        static void Main(string[] args)
        {
            WaitOrPressKey(TimeSpan.FromSeconds(10));
        }
    }
}
