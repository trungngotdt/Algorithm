using System;

namespace QuickSortLib
{
    public class QuickSort
    {
        public void Sort(int[] A, int l, int r)
        {
            if (l >= r) return;
            int i = l;
            int j = r;
            int x = A[(l + r) / 2];
            while (i <= j)
            {
                while (A[i] < x)
                {
                    i++;
                }
                while (A[j] > x)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temp = A[i];
                    A[i] = A[j];
                    A[j] = temp;
                    i++;
                    j--;
                }
            }
            Sort(A, l, j);
            Sort(A, i, r);

        }
    }
}
