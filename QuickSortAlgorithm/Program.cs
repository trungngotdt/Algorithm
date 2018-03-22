using QuickSortLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSortAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int len = 1000000;
            int[] A=new int[len];

            Random rand = new Random();
            for (int i = 0; i < len; i++)
            {
                int cc = rand.Next();//
                A[i]  = rand.Next() + i * cc + rand.Next() / 2 + 1 + rand.Next() / 3 + cc * i / 2;
            }
            QuickSort quickSort = new QuickSort();
            quickSort.Sort(A, 0, A.Length - 1);
        }
    }
}
