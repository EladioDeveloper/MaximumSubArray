using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Practice_6 {
    class Program {
        static void Main (string[] args) {
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