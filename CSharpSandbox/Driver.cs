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
            Lambdas.LambdaPractice2(i => i.myVal++);
            
            //Dijkstra.Calculate();

			//foreach (var rel in Dijkstra.GenerateNodeTree(10))
			//{
			//	Console.WriteLine(rel.start + " -> " + rel.end + ": " + rel.distance + " units");
			//}
			//Console.Read();
		}
	}
}
