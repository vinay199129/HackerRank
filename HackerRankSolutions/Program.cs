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

        // Complete the minimumBribes function below.
        static void MinimumBribes(int[] q)
        {
            int minBribes = 0;
            bool isTooChaotic = false;
            for (int i = 0; i < q.Length; i++)
            {
                if (q[i] > (i + 1) + 2)
                {
                    isTooChaotic = true;
                    break;
                }
                for (int j = Math.Max(0, q[i] - 2); j < i; j++)
                {
                    if (q[j] > q[i]) { minBribes++; }
                }

            }
            Console.WriteLine(isTooChaotic ? "Too chaotic" : minBribes.ToString());
        }

        // Complete the minimumSwaps function below.
        static int MinimumSwaps(int[] arr)
        {
            int swaps = 0;
            int tmp;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                while (arr[i] != i + 1)
                {
                    tmp = arr[arr[i] - 1];
                    arr[arr[i] - 1] = arr[i];
                    arr[i] = tmp;
                    swaps++;
                }
            }
            return swaps;
        }

        // Complete the arrayManipulation function below.
        static long ArrayManipulation(int n, int[][] queries)
        {
            var data = new int[n + 1];
            for (int i = 0; i < queries.Length; i++)
            {
                int a = queries[i][0];
                int b = queries[i][1];
                int k = queries[i][2];
                data[a - 1] += k;
                data[b] -= k;
            }
            long sum = 0;
            long max = 0;
            foreach (var num in data)
            {
                sum += num;
                if (max < sum)
                    max = sum;
            }
            return max;
        }

        // Complete the reverseArray function below.
        static int[] ReverseArray(int[] a)
        {
            int[] reversedArr = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                reversedArr[i] = a[a.Length - i - 1];
            }
            return reversedArr;
        }


        static float Median(int[] count, int d)
        {
            int d2 = (d + 1) / 2;
            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] > d2)
                {
                    return i;
                }
                if (count[i] == d2)
                {
                    if (d % 2 != 0)
                        return i;
                    for (int j = i + 1; j < count.Length; j++)
                    {
                        if (count[j] > 0)
                            return (i + j) / 2.0f;
                    }
                }
                d2 -= count[i];
            }
            return 0;
        }


        // Complete the activityNotifications function below.
        static int ActivityNotifications(int[] expenditure, int d)
        {
            int result = 0;
            int[] count = new int[201];

            for (int i = 0; i < expenditure.Length; i++)
            {
                int v = expenditure[i];
                if (i >= d)
                {
                    var m = Median(count, d);
                    if (v >= 2 * m)
                        result++;
                    count[expenditure[i - d]]--;
                }
                count[v]++;
            }
            return result;
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
            //string[] nd = Console.ReadLine().Split(' ');

            //int n = Convert.ToInt32(nd[0]);

            //int d = Convert.ToInt32(nd[1]);

            //int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));
            //int[] result = RotLeft(a, d);

            //Min Bribes
            //int t = Convert.ToInt32(Console.ReadLine());

            //for (int tItr = 0; tItr < t; tItr++)
            //{
            //    int n = Convert.ToInt32(Console.ReadLine());

            //    int[] q = Array.ConvertAll(Console.ReadLine().Split(' '), qTemp => Convert.ToInt32(qTemp));
            //    MinimumBribes(q);
            //}

            // Complete the minimumSwaps function below.
            //int n = Convert.ToInt32(Console.ReadLine());

            //int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));

            //int res = MinimumSwaps(arr);


            // Complete the arrayManipulation function below.
            //string[] nm = Console.ReadLine().Split(' ');

            //int n = Convert.ToInt32(nm[0]);

            //int m = Convert.ToInt32(nm[1]);

            //int[][] queries = new int[m][];

            //for (int i = 0; i < m; i++)
            //{
            //    queries[i] = Array.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
            //}

            //long result = ArrayManipulation(n, queries);

            // Complete the reverseArray function below.
            //int arrCount = Convert.ToInt32(Console.ReadLine());

            //int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            //int[] res = ReverseArray(arr);

            // Complete the activityNotifications function below.
            string[] nd = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nd[0]);

            int d = Convert.ToInt32(nd[1]);

            int[] expenditure = Array.ConvertAll(Console.ReadLine().Split(' '), expenditureTemp => Convert.ToInt32(expenditureTemp));

            int result = ActivityNotifications(expenditure, d);
        }
    }
}
