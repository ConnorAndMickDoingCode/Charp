/*
   @author:         Mick Torres
   @course:         CST-201
   @assignment:     Individual Assignment 3
   @citations:      google, textbook, geeksforgeeks, youtube, stackoverflow

    Insertion sort goes sequentially through the array when making comparisons to find
    a proper place for an element currently processed. Consider using binary search
    instead and give a complexity of the resulting insertion sort.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_3
{
    public class _9_7_6
    {
        
        public static void Main(string[] args)
        {
            int[] arr = { 37, 23, 0, 17, 12, 72, 31, 46, 100, 88, 54 };

            _9_7_6 stuff = new _9_7_6();

            stuff.Sort(arr);
            Console.Write("Sorted Array: ");
            for (int i = 0; i < arr.Length; i++)
            {
                //Console.WriteLine("Unsorted Array: " + arr);
                Console.Write(arr[i] + " ");
            }
        }

        public void Sort(int[] array)
        {
            //create sort method ...
            for (int i = 1; i < array.Length; i++)
            {
                int x = array[i];

                int j = Math.Abs(Array.BinarySearch(array, 0, i, x) + 1);

                foreach (var item in array)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
                Console.WriteLine("\tx: " + x);
                Console.WriteLine("\tj: " + j);
                Console.WriteLine("\tarray[i]: " + array[i]);
                Console.WriteLine("\tarray[j]: " + array[j]);

                System.Array.Copy(array, j, array, j + 1, i - j);

                array[j] = x;

                
            }

        }
    }
}
