/*
   @author:         Mick Torres
   @course:         CST-201
   @assignment:     Individual Assignment 3
   @citations:      google, textbook, geeksforgeeks, youtube, stackoverflow

    Implement and test mergesort().
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_3
{
    public class _9_7_10
    {
        /*
        public static void Main(string[] args)
        {
            int[] arr = { 12, 11, 13, 5, 6, 7 };
            Console.WriteLine("Given Array:");
            PrintArray(arr);

            _9_7_10 ob = new _9_7_10();
            ob.Sorts(arr, 0, arr.Length - 1);

            Console.WriteLine("\nSorted Array");
            PrintArray(arr);
        }

        public void Merge(int[] arr, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;

            int[] L = new int[n1];
            int[] R = new int[n2];

            for (int w = 0; w < n1; w++)
            {
                L[w] = arr[l + w];
            }
            for (int h = 0; h < n2; h++)
            {
                R[h] = arr[m + 1 + h];
            }

            int i = 0, j = 0;

            int k = l;
            while(i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }
            while ( i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            while ( j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        public void Sorts(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int m = (l + r)/2;

                Sorts(arr, l, m);
                Sorts(arr, m + 1, r);

                Merge(arr, l, m, r);
            }
        }

        public static void PrintArray(int[] arr)
        {
            int n = arr.Length;
            for ( int i = 0; i < n; i++)
            {
                Console.WriteLine(arr[i] + " ");
            }
            Console.WriteLine(); ;
        }
        */
    }
}
