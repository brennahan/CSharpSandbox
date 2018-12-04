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
	class Sorting
    {
        public static int[] SortList(int[] inputList)
        {
            int endUnsortedIndex = inputList.Length - 1;
            int largeIndex = 0;

            while (endUnsortedIndex != 0)
            {
                //Find Next Largest
                for (int i = 0; i <= endUnsortedIndex; i++)
                    if (inputList[i] > inputList[largeIndex])
                        largeIndex = i;

                if (largeIndex != endUnsortedIndex)
                {
                    //Swap - no temp variable
                    inputList[largeIndex] += inputList[endUnsortedIndex];
                    inputList[endUnsortedIndex] = inputList[largeIndex] - inputList[endUnsortedIndex];
                    inputList[largeIndex] = inputList[largeIndex] - inputList[endUnsortedIndex];
                }
        
                //Reset and increment counters
                endUnsortedIndex--;
                largeIndex = 0;
            }

            return inputList;
        }

    }
}
