using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSum
{
    class TwoSum
    {
        /// <summary>
        /// Indique si une liste contient deux nombre pouvant former la somme souhaîtée
        /// </summary>
        /// <param name="list">La liste</param>
        /// <param name="sum">La somme souhaîtée</param>
        /// <returns>Vrai ou Faux</returns>
        static bool HasTwoSum(IList<int> list, int sum)
        {
            HashSet<int> hs = new HashSet<int>();
            for (int i = 0; i < list.Count; i++)
            {
                // Calcule du nombre dont on a besoin
                var needed = sum - list[i];
                // A-t-on déjà trouvé le nombre dont on a besoin ?
                if (hs.Contains(needed))
                {
                    return true;
                }
                // Ajout du nombre actuel
                hs.Add(list[i]);
            }
            return false;
        }

        static Tuple<int, int> FindTwoSum(IList<int> list, int sum)
        {
            HashSet<int> hs = new HashSet<int>();
            for (int i = 0; i < list.Count; i++)
            {
                // Calcule du nombre dont on a besoin
                var needed = sum - list[i];
                // A-t-on déjà trouvé le nombre dont on a besoin ?
                if (hs.Contains(needed))
                {
                    return Tuple.Create(list.IndexOf(needed), i);
                }
                // Ajout du nombre actuel
                hs.Add(list[i]);
            }
            return null;
        }

        /// <summary>
        /// Renvoit les indices des trouvées x fois
        /// </summary>
        /// <param name="list"></param>
        /// <param name="sum"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        static List<Tuple<int, int>> FindTwoSumXTime(IList<int> list, int sum, int time = 1)
        {
            if (time < 1)
                return null;

            List<Tuple<int, int>> res = new List<Tuple<int, int>>();
            HashSet<int> hs = new HashSet<int>();
            for (int i = 0; i < list.Count; i++)
            {
                // Calcule du nombre dont on a besoin
                var needed = sum - list[i];
                // A-t-on déjà trouvé le nombre dont on a besoin ?
                if (hs.Contains(needed))
                {
                    if (0 != time--)
                    {
                        res.Add(Tuple.Create(list.IndexOf(needed), i));
                        if (time == 0)
                            return res;
                    }
                }
                // Ajout du nombre actuel
                hs.Add(list[i]);
            }
            return null;
        }
        
        static void Main(string[] args)
        {
            //Tuple<int, int> indices = FindTwoSum(new List<int>() { 1, 3, 5, 7, 9 }, 12);
            //Console.WriteLine(indices.Item1 + " " + indices.Item2);

            foreach (var item in FindTwoSumXTime(new List<int>() { 1, 3, 5, 7, 9, 11 }, 12, 3) ?? new List<Tuple<int, int>>())
            {
                Console.WriteLine(item.Item1 + " " + item.Item2);
            }

            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }
    }
}
