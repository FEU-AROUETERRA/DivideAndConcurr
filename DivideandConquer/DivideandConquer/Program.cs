using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideandConquer
{
    class Program
    {
        public static int DVC(int[] N, int head, int tail, int maximum)
        {
            int partition = maximum / 2, part2 = partition, LSum = 0;
            var LeftHand = new List<int>();
            var RightHand = new List<int>();
            for (int i = head; i <= tail; i++)
            {
                LSum += N[i];
                if (LSum > partition) break;
                if (LSum == partition)
                {
                    int LFinal = DVC(N, head, i, partition);
                    int RFinal = DVC(N, i + 1, tail, partition);
                    return Bigger(LFinal, RFinal);
                }
            }
            return 0;
        }
        public static int Bigger(int a, int b)
        {
            return a > b ? a : b;
        }
        static void Main(string[] args)
        {
            int[] N;
            List<string> str = new List<string>();
            Console.WriteLine(" ");
            Console.WriteLine("Input: ");
            string s = Console.ReadLine();
            str = s.Split(',').ToList();
            N = str.Select(int.Parse).ToArray();
            int maximum = N.Length;
            var tp = DVC(N, 0, maximum - 1, maximum);
            Console.WriteLine(tp);
            //tp.Sum();
            Console.ReadLine();
        }
    }
}
