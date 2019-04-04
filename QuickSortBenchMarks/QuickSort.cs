using System;

namespace QuickSortBenchMarks
{
    public class QuickSort
    {
        public int[] array = new int[100005];
        public QuickSort()
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(array.Length);
            }
        }

        public void QuickSortOriginal(int l,int r)
        {
        
            if (l >= r) return;
            int start = l + 1;
            int end = r;
            int pos = l;

            while(true)
            {
                while(end > l &&array[pos]<array[end])
                {
                    end--;
                }
                while(start < r&&array[pos]>array[start])
                {
                    start++;
                }
                if (end <= start)
                    break;
                array[start] = array[start] + array[end];
                array[end] = array[start] - array[end];
                array[start] = array[start] - array[end];
                start++;
                end--;
               
            }
            if (end != pos)
            {
                array[end] = array[end] + array[pos];
                array[pos] = array[end] - array[pos];
                array[end] = array[end] - array[pos];
            }

            QuickSortOriginal(l, end - 1);
            QuickSortOriginal(end + 1, r);
        }
    }
}
