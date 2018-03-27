using BubbleSortLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSortTest
{
    class Program
    {
        static void Main(string[] args)
        {
            BubbleSort bubbleSort = new BubbleSort(new int[] {9,5,1,7,4,6,8,2,3 });
            bubbleSort.Sort();
        }
    }
}
