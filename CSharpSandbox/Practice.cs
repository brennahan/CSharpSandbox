using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;


namespace CSharpSandbox
{
    class Practice
    {
        public static myReturnObject KadaneAlgorithm(int[] inputList)
        {
            //NOTE: WIP. This doesn't properly identify the largest sequence as it doesn't handle sequeces like 1, -1, 1 properly. 
            //It needs to look at the whole sequence. Likely need to remake the logic here. Ideas:
            //1) Crunch all positive sets into single value while preserving start/end index from original array. Custom class/struct probably.
            //2) 
            int currentMaxStart = 0;
            int currentMaxEnd = 0;
            int currentMaxTotal = inputList[0];
            int previousTotal = inputList[0];
            int runningTotal = inputList[0];

            for (int i = 0;  i < inputList.Length; i++){
                runningTotal = inputList[i];
                previousTotal = inputList[i];

                for (int j = i; j < inputList.Length; j++)
                {
                    if (i != j)
                        runningTotal += inputList[j];

                    if (runningTotal >= previousTotal)
                    {
                        previousTotal = runningTotal;

                        if (runningTotal >= currentMaxTotal)
                        {
                            currentMaxStart = i;
                            currentMaxEnd = j;
                            currentMaxTotal = runningTotal;
                        }
                    }
                    else break;

                    previousTotal += inputList[j];
                    
                }
            }

            return new myReturnObject() { Start = currentMaxStart, End = currentMaxEnd, Total = currentMaxTotal };
        }

        public class myReturnObject
        {
            public int Start { get; set; }
            public int End { get; set; }
            public int Total { get; set; }
        }
    }
}
