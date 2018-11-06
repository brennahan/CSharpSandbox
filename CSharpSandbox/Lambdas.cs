using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSandbox
{
    class Lambdas
    {
        public static void LambdaPractice(Func<int, int, int, int> predicate)
        {
            int input1 = 2;
            int input2 = 5;
            int input3 = 7;
            var result = predicate(input1, input2, input3);

            Console.WriteLine("Input(s): " + input1 + ", " + input2 + ", " + input3);
            Console.WriteLine("Result: " + result);
            Console.Read();
        }

        public static void LambdaPractice2(Action<customObject> action)
        {
            customObject temp = new customObject();
            temp.myVal = 10;

            Console.WriteLine("Input(s): " + temp.myVal);
            action.Invoke(temp);
            Console.WriteLine("Result: " + temp.myVal);
            Console.Read();
        }
    }

    class customObject
    {
        public int myVal { get; set; }
    }
}
