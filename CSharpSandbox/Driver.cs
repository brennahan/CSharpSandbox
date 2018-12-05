using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSandbox
{
	class Driver
	{
		static void Main(string[] args)
		{
            //DPC303.Hard();
            //DPC364.Easy();
            //DPC364.Intermediate();
            //DPC365.Easy();
            //DPC365.Intermediate();

            //Lambdas.LambdaPractice((i, j, k) => i*j*k);
            //Lambdas.LambdaPractice2(i => i.myVal++);

            //Dijkstra.Calculate();

            //foreach (var rel in Dijkstra.GenerateNodeTree(10))
            //{
            //	Console.WriteLine(rel.start + " -> " + rel.end + ": " + rel.distance + " units");
            //}

            //Console.WriteLine(string.Join(", ", Sorting.SortList(new int[] { 6, 2, 7, 9, 1, 5, 3, 4, 8 })));

            //var result = Practice.KadaneAlgorithm(new int[] { 1, 2, -1, 5, -6, 2 } );
            //Console.WriteLine("Start:" + result.Start + "__End:" + result.End + "__Total:" + result.Total);

            //var sum = InterviewPractice.OperatorlessAddition1(3, 5);
            //Console.WriteLine(sum);

            //var sum = InterviewPractice.OperatorlessAddition2(18, 52);
            //Console.WriteLine(sum);

            //var result = InterviewPractice.FindTwoMissingNumbers(new int[] { 7, 1, 5, 4, 8, 10, 6, 2 });
            //Console.WriteLine(result.Item1 + ", " + result.Item2);

            //Console.WriteLine(InterviewPractice.Fibonacci(8));

            //InterviewPractice.CountChars("How do you do detective, I'm hungry.");

            InterviewPractice.FindAllSubstrings("apple");

            Console.Read();
        }
    }
}
