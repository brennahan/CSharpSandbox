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
    }
}
