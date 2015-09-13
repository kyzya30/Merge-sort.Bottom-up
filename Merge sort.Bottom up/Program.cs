using System;

namespace Merge_sort.Bottom_up
{
    class Program
    {
        public static void Main()
        {
            int[] myArray = new int[] { 6, 2, 3, 9, 5, 4 };
            Sort(myArray);
            foreach (var item in myArray)
            {
                Console.WriteLine(item);
            }
        }
        static void Sort(int[] myArray)
        {
            int n = myArray.Length;
            int[] targetArr = new int[n];
            int[] sourceArr = myArray;
            
            for (int range = 1; range < n; range += range)
            {
                for (int cnt = 0; cnt < n; cnt += range + range)
                {
                    int val1 = Math.Min(n, cnt + range);
                    int val2 = Math.Min(n, val1 + range);
                    Merge(sourceArr, targetArr, cnt, val1, val2);
                }
                int[] tempArr = sourceArr;
                sourceArr = targetArr;
                targetArr = tempArr;
            }
            if (myArray != sourceArr)
            {
                for (int i = 0; i < n; i++)
                {
                    myArray[i] = sourceArr[i];
                }
            }
        }
        static void Merge(int[] source, int[] target, int a, int val1, int val2)
        {
            int topAValue = val1;
            int topBValue = val2;
            int i = a;
            while (a < topAValue || val1 < topBValue)
            {
                if (a == topAValue)
                {
                    target[i++] = source[val1++];
                }
                else if (val1 == topBValue)
                {
                    target[i++] = source[a++];
                }
                else if (source[a] <= source[val1])
                {
                    target[i++] = source[a++];
                }
                else
                {
                    target[i++] = source[val1++];
                }
            }
        }
    }
}
