using System;

namespace SelectionSort
{
    public class SelectionSort
    {
        private int[] array;
        public SelectionSort(int[] array)
        {
            this.Array = array;
        }

        public int[] Array { get => array; set => array = value; }

        public void Selection()
        {
            if (Array==null)
            {
                return;
            }
            for (int i = Array.Length-1; i >=1; i--)
            {
                int index = i;
                for (int j = 0; j < i; j++)
                {
                    if (Array[j]>Array[index])
                    {
                        index = j;
                    }
                    int temp = Array[index];
                    Array[index] = Array[i];
                    Array[i] = temp;
                }
            }
        }
    }
}
