using System;
using System.Collections.Generic;

namespace TrainComposition
{
    public class TrainComposition
    {
        LinkedList<int> train = new LinkedList<int>();
        public void AttachWagonFromLeft(int wagonId)
        {
            train.AddFirst(wagonId);
        }

        public void AttachWagonFromRight(int wagonId)
        {
            train.AddLast(wagonId);
        }

        public int DetachWagonFromLeft()
        {
            var first = train.First;
            train.RemoveFirst();
            return first.Value;
        }

        public int DetachWagonFromRight()
        {
            var last = train.Last;
            train.RemoveLast();
            return last.Value;
        }

        public static void Main(string[] args)
        {
            TrainComposition tree = new TrainComposition();
            tree.AttachWagonFromLeft(7);
            tree.AttachWagonFromLeft(13);
            Console.WriteLine(tree.DetachWagonFromRight()); // 7 
            Console.WriteLine(tree.DetachWagonFromLeft()); // 13
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }
    }
}
