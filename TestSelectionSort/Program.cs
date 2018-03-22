using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            SelectionSort.SelectionSort sort=new SelectionSort.SelectionSort(new int[]{29,10,14,37,13 });
            sort.Selection();

        }
    }
}
