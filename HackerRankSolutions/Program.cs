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

        // Complete the jumpingOnClouds function below.
        private static int JumpingOnClouds(int[] c)
        {
            Int32 numberOfJumps = 0;
            for (int i = 0; i < c.Length - 1; i++)
            {
                //Initially we are at first position
                //for every time check if it is safe to jump 2 else jump 1
                if (i + 2 <= (c.Length - 1) && c[i + 2] == 0)
                {
                    //safe to jump 2 move, increase the counter as well
                    numberOfJumps += 1;
                    i += 1;
                }
                else if (i + 1 <= (c.Length - 1) && c[i + 1] == 1)
                {
                    //avoid jump on this one
                    i += 1;
                }
                else
                {
                    numberOfJumps += 1;
                }
            }
            return numberOfJumps;
        }

        // Complete the repeatedString function below.
        static long RepeatedString(string s, long n)
        {
            long noOfOccurence = 0;
            noOfOccurence += (s.Count(x => x == 'a') * (n / s.Length)) + s.Take(Convert.ToInt32(n % s.Length)).Count(x => x == 'a');
            return noOfOccurence;
        }

        // Complete the countSwaps function below.
        static void CountSwaps(int[] a)
        {
            int numberOfSwaps = 0;
            int t;
            for (int i = 0; i <= a.Length - 2; i++)
            {
                for (int j = 0; j <= a.Length - 2; j++)
                {
                    // Swap adjacent elements if they are in decreasing order
                    if (a[j] > a[j + 1])
                    {
                        t = a[j + 1];
                        a[j + 1] = a[j];
                        a[j] = t;
                        numberOfSwaps += 1;
                    }
                }
            }
            Console.WriteLine($"Array is sorted in {numberOfSwaps} swaps.");
            Console.WriteLine($"First Element: {a[0]}");
            Console.WriteLine($"Last Element: {a[a.Length - 1]}");
        }

        // Complete the maximumToys function below.
        static int MaximumToys(int[] prices, int k)
        {
            //for (int i = 0; i <= prices.Length - 2; i++)
            //{
            //    for (int j = 0; j <= prices.Length - 2; j++)
            //    {
            //        // Swap adjacent elements if they are in decreasing order
            //        if (prices[j] > prices[j + 1])
            //        {
            //            var temp = prices[j + 1];
            //            prices[j + 1] = prices[j];
            //            prices[j] = temp;
            //        }
            //    }
            //}

            prices = prices.OrderBy(x => x).ToArray();
            Int32 numberOfToys = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < k)
                {
                    numberOfToys += 1;
                    k -= prices[i];
                }
            }
            return numberOfToys;
        }

        // Complete the hourglassSum function below.
        static int HourglassSum(int[][] arr)
        {
            int maxHourGlassSum = int.MinValue, currentHourGlassSum = 0;
            for (int i = 0; i < arr.Length - 2; i++)
            {
                for (int j = 0; j < arr.Length - 2; j++)
                {
                    currentHourGlassSum = arr[i][j] + arr[i][j + 1] + arr[i][j + 2] + arr[i + 1][j + 1] + arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2];
                    if (currentHourGlassSum > maxHourGlassSum || maxHourGlassSum == 0)
                    {
                        maxHourGlassSum = currentHourGlassSum;
                    }
                }
            }
            return maxHourGlassSum;
        }

        // Complete the rotLeft function below.
        static int[] RotLeft(int[] a, int d)
        {
            List<int> updArray = new List<int>();
            for (int i = 0; i < d; i++)
            {
                updArray.Add(a[i]);
            }
            for (int i = a.Length; i > d; i--)
            {
                updArray.Insert(0, a[i - 1]);
            }
            return updArray.ToArray();
        }


        static void Main(string[] args)
        {
            //Sock Merchant Problem
            //int n = Convert.ToInt32(Console.ReadLine());
            //int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));
            //int result = SockMerchant(n, ar);

            //valley Counting
            //int n = Convert.ToInt32(Console.ReadLine());
            //string s = Console.ReadLine();
            //int result = CountingValleys(n, s);

            //Jumping on the Clouds
            //int n = Convert.ToInt32(Console.ReadLine());
            //int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp));
            //int result = JumpingOnClouds(c);

            //string s = Console.ReadLine();
            //long n = Convert.ToInt64(Console.ReadLine());
            //long result = RepeatedString(s, n);

            //maximumToys
            //string[] nk = Console.ReadLine().Split(' ');

            //int n = Convert.ToInt32(nk[0]);

            //int k = Convert.ToInt32(nk[1]);

            //int[] prices = Array.ConvertAll(Console.ReadLine().Split(' '), pricesTemp => Convert.ToInt32(pricesTemp));
            //int result = MaximumToys(prices, k);

            //Hour Glass Sum
            //int[][] arr = new int[6][];

            //for (int i = 0; i < 6; i++)
            //{
            //    arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            //}

            //int result = HourglassSum(arr);

            //rotLeft function
            string[] nd = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nd[0]);

            int d = Convert.ToInt32(nd[1]);

            int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));
            int[] result = RotLeft(a, d);

        }
    }
}
