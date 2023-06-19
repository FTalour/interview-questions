using System;

namespace SortedSearch
{
    class SortedSearch
    {
        static int CountNumbers(int[] sortedArray, int lessThan)
        {
            int lengthOfArray = sortedArray.Length;
            if (lengthOfArray == 0) return 0;
            if (sortedArray[lengthOfArray - 1] < lessThan) return lengthOfArray;

            if (sortedArray[0] >= lessThan) return 0;
            
            int index = Array.BinarySearch(sortedArray, lessThan);
            if (index < 0)
                return ~index;
            for (; index > 0 && sortedArray[index - 1] == lessThan; index--) ;

            return index;
        }

        static int FindIndexGreaterOrEqualIndex(int[] sortedArray, int lessThan, int begin, int end)
        {
            if (begin > end)
                return -1;
            
            if (begin == end)
            {
                if (sortedArray[end] < lessThan)
                    return end;
                return -1;
            }
            
            // auto ceiling
            int mid = (begin + end) / 2;

            // the boundary is in [begin, mid)
            if (lessThan < sortedArray[mid])
            {
                if (begin == mid)
                    return begin;

                return FindIndexGreaterOrEqualIndex(sortedArray, lessThan, begin, mid);
            }
            // the boundary is [mid; end]
            else if (mid + 1 == end)
                return lessThan < sortedArray[end] ? mid : end;

            // the boundary is in (mid, end]
            return FindIndexGreaterOrEqualIndex(sortedArray, lessThan, mid + 1, end);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(SortedSearch.CountNumbers(new int[] { 1, 2, 3, 4, 5, 7 }, 6));
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }
    }
}
