using System;

namespace BubbleSortLib
{
    public class BubbleSort
    {
        private int[] array;

        public int[] Array { get => array; set => array = value; }
        public BubbleSort(int[] array)
        {
            this.Array = array;
        }

        public void Sort()
        {
            int n = Array.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n-i-1; j++)
                {
                    if (Array[j]>Array[j+1])
                    {
                        int temp = Array[j];
                        Array[j] = Array[j + 1];
                        Array[j + 1] = temp;
                    }
                }
                
            }
        }
    }
}
