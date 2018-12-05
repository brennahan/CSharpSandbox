using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSandbox
{
    class InterviewPractice
    {
        //Directions: Sum 2 numbers without using any operators (Used list length 'range' join).
        //Status: Completed
        public static int OperatorlessAddition1(int num1, int num2)
        {
            List<bool> list1 = new List<bool>(num1);
            list1.AddRange(Enumerable.Repeat(true, num1));
            List<bool> list2 = new List<bool>(num2);
            list2.AddRange(Enumerable.Repeat(true, num2));

            list1.AddRange(list2);

            return list1.Count;
        }

        //Directions: Sum 2 numbers without using any operators (bitwise operator, bitshift, etc.).
        //Status: Completed
        public static int OperatorlessAddition2(int num1, int num2)
        {
            int carry = (num1 & num2) << 1;
            int prevCarry = carry;
            int partialSum = num1 ^ num2;


            while (carry != 0) {
                prevCarry = carry;
                carry = (prevCarry & partialSum) << 1;
                
                partialSum = prevCarry ^ partialSum;
            }

            return partialSum;
        }

        //Directions: Given a list of ints, find the 2 missing numbers in the chain.
        //Status: Completed
        public static Tuple<int,int> FindTwoMissingNumbers(int[] myList)
        {
            int num1 = -1;
            int num2 = -1;
            bool[] fullList = new bool[myList.Length + 2];

            foreach (var val in myList)
                fullList[val - 1] = true;

            for (int i = 0; i < fullList.Length; i++)
                if (!fullList[i])
                {
                    if (num1 == -1)
                        num1 = i + 1;
                    else
                    {
                        num2 = i + 1;
                        break;
                    }
                }

            return new Tuple<int, int>(num1, num2);
        }

        //Directions: Standard fibonacci
        //Status: Completed
        public static int Fibonacci(int length)
        {
            int tailIndex = 1;
            int counter = 2;
            int[] arr = new int[3];
            arr[0] = 0;
            arr[1] = 1;

            if (length <= 2)
                return -1;

            while (counter < length)
            {
                arr[Fibonacci_Mod(tailIndex + 1, 3)] = arr[Fibonacci_Mod(tailIndex, 3)] + (arr[Fibonacci_Mod(tailIndex - 1, 3)]);

                tailIndex = Fibonacci_Mod(tailIndex + 1, 3);
                counter++;
            }


            return arr[Math.Min(tailIndex, length - 1)];
        }

        private static int Fibonacci_Mod(int num, int mod)
        {
            return (num % mod + mod) % mod;
        }

        //Directions: Count the occurence of each character in String
        //Status: Completed
        public static void CountChars(string input)
        {
            //input = input.ToLower();

            Dictionary<char, int> occurences = new Dictionary<char, int>();
            
            for(int i = 0; i < input.Length; i++)
            {
                if (occurences.ContainsKey(input[i]))
                    occurences[input[i]]++;
                else
                    occurences.Add(input[i], 1);
            }

            foreach(var entry in occurences)
            {
                Console.WriteLine(entry.Key + ": " + entry.Value);
            }
        }

        //Directions: Find all substrings given a string. Throw out Duplicate substrings.
        //Status: Completed
        public static void FindAllSubstrings(string input)
        {
            string subString;

            //TEST AREA
            Dictionary<string, bool> dictionary = new Dictionary<string, bool>();


            for(int i = 0; i < input.Length; i++)
            {
                subString = "";
                for (int j = i; j < input.Length; j++)
                {
                    subString += input[j];
                    if (!dictionary.ContainsKey(subString)) dictionary.Add(subString, true);
                }
            }

            var myReturn = dictionary.Keys.ToArray();

            foreach (var val in myReturn)
                Console.WriteLine(val);
        }
    }
}
