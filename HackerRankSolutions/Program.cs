using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions
{
    class Program
    {

        // Complete the sockMerchant function below.
        private static int SockMerchant(int n, int[] ar)
        {
            //Get Distinct Colors/values with count
            Dictionary<Int32, Int32> dicColorCount = ar.GroupBy(x => x).Where(x => x.Count() > 1).ToDictionary(x => x.Key, x => x.Count() / 2);
            return dicColorCount.Sum(x => x.Value);
        }


        // Complete the countingValleys function below.
        private static int CountingValleys(int n, string s)
        {
            Int32 valleyCount = 0, currentLevel = 0;
            bool atBaseLevel = true;
            foreach (var item in s)
            {
                if (item == 'D')
                {
                    currentLevel -= 1;
                }
                else
                {
                    currentLevel += 1;
                }
                if (currentLevel < 0 && atBaseLevel == true)
                {
                    valleyCount += 1;                    
                }
                atBaseLevel = currentLevel == 0;
            }
            return valleyCount;
        }
        static void Main(string[] args)
        {
            //Sock Merchant Problem
            //int n = Convert.ToInt32(Console.ReadLine());
            //int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));
            //int result = SockMerchant(n, ar);

            int n = Convert.ToInt32(Console.ReadLine());

            string s = Console.ReadLine();

            int result = CountingValleys(n, s);

        }
    }
}
