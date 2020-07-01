using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Practice_6 {
    class Program {
        static void Main (string[] args) {

            //Demo
            int[] array1 = new int[] { 1, 2, 3, 4 };
            int[] array2 = new int[] { 2, -1, 2, 3, 4, -5 };
            List<List<int>> lista = new List<List<int>> ();

            lista.Add (new List<int> { MaxSubArray (array1), MaxSum (array1) });
            lista.Add (new List<int> { MaxSubArray (array2), MaxSum (array2) });

            foreach (var items in lista) {
                Console.WriteLine ();
                foreach (var item in items) {
                    Console.Write ($"{item} ");
                }
            }
            Console.ReadKey ();
            //-------------------------------------------------------------------

            List<List<int>> list = new List<List<int>> { };
            int t = int.Parse (Console.ReadLine ());
            for (int i = 0; i < t; i++) {
                int n = int.Parse (Console.ReadLine ());
                string str = Console.ReadLine ();
                int[] array = str.Split (" ").Select (int.Parse).ToArray ();
                List<int> listTemp = new List<int> { MaxSubArray (array), MaxSum (array) };
                list.Add (listTemp);
            }

            foreach (var items in list) {
                Console.WriteLine ();
                foreach (var item in items) {
                    Console.Write ($"{item} ");
                }
            }
        }

        private static int MaxSubArray (int[] Array) {
            int currentSum = 0;
            int maxSum = int.MinValue;
            for (int i = 0; i < Array.Length; i++) {
                currentSum += Array[i];
                if (maxSum < currentSum) {
                    maxSum = currentSum;
                }

                if (currentSum < 0) {
                    currentSum = 0;
                }
            }

            return maxSum;
        }
        private static int MaxSum (int[] Array) {
            Array = Array.OrderByDescending (x => x).ToArray ();
            int biggest = Array[0];
            int i = 0;
            foreach (var item in Array) {
                if (i != 0) {
                    if (item < 0) {
                        if (biggest < item)
                            biggest = item;
                        break;
                    }
                    biggest += item;
                }
                i++;
            }
            return biggest;
        }
    }
}