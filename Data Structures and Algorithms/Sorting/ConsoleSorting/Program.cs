using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSorting
{
    class Program
    {
        static void InsertSort(ref int[] arr)
        {
            int j = 0;
            int temp = 0;
            for(int i = 0; i < arr.Length - 1; i++)
            {
                if(arr[i] > arr[i + 1])
                {
                    temp = arr[i + 1];
                    arr[i + 1] = arr[i];
                    j = i;
                    while(j > 0 && temp < arr[j - 1])
                    {
                        arr[j] = arr[j - 1];
                        j--;
                    }
                    arr[j] = temp;

                }
            }
        }

        static void SelectionSort(ref int[] arr)
        {
            int min;
            for(int i = 0; i < arr.Length - 1; i++)
            {
                min = i; 
                for(int j = i + 1; j < arr.Length; j++)
                {
                    if(arr[j] < arr[min])
                    {
                        min = j;
                    }
                }
                if(min != i)
                {
                    int temp = arr[min];
                    arr[min] = arr[i];
                    arr[i] = temp;
                }
            }
        }

        static int[] Sort(int[] arr)
        {
            if(arr.Length  > 1)
            {
                int[] left = new int[arr.Length / 2];
                int[] right = new int[arr.Length - left.Length];

                for (int i = 0; i < left.Length; i++)
                {
                    left[i] = arr[i];
                }
                for (int i = 0; i < right.Length; i++)
                {
                    right[i] = arr[left.Length + i];
                }

                if (left.Length > 1)
                {
                   left = Sort(left);
                }
                if(right.Length > 1)
                {
                    right = Sort(right);
                }

                arr = MergeSort(left, right);
            }
            return arr;
        }

        static int[] MergeSort(int[] left, int[] right)
        {
            int[] arr = new int[left.Length + right.Length];
            int i = 0;
            int l = 0;
            int r = 0;

            for(; i < arr.Length; i++)
            {
                if (r >= right.Length)
                {
                    arr[i] = left[l];
                    l++;
                }
                else if(l < left.Length &&  left[l] < right[r])
                {
                    arr[i] = left[l];
                    l++;
                }
                else
                {
                    arr[i] = right[r];
                    r++;
                }
                
            }
            return arr;
        }

        static int[] QuickSort(int[] arr, int low, int high)
        {
            int i = low;
            int j = high;

            int middle = arr[(i + j) / 2];

            do
            {
                while (arr[i] < middle)
                {
                    ++i;
                }
                while (arr[j] > middle)
                {
                    --j;
                }
                if (i <= j)
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i++;
                    j--;
                }
            } while (i < j);
            if(low < j)
            {
                QuickSort(arr, low, j);
            }
            if(i < high)
            {
                QuickSort(arr, i, high);
            }
            return arr;
        }

        static void Main(string[] args)
        {
            
        }
    }
}
