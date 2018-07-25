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
	class Dijkstra
	{
		public static void Calculate()
		{
			Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
			var rawAirports = System.IO.File.ReadAllLines("..\\..\\Inputs\\Dijkstra.txt").Select(i => CSVParser.Split(i));

			var trimmedAirports = rawAirports.Select(r => new { ID = Int32.Parse(r.ElementAt(0)), Latitude = double.Parse(r.ElementAt(6)), Longitude = double.Parse(r.ElementAt(7)), Altitude = Int32.Parse(r.ElementAt(8)) }).ToArray();

		}

		public struct Distance {
			public int startID, endID, distance;
		}

		public static List<Relationship> GenerateNodeTree(int nodeCount)
		{
			//Assumed nodeCount is greater than 3
			List<Relationship> nodeRelationshipList = new List<Relationship>();

			int currentNode = 0;
			int endNode = 1;
			Random rand = new Random();
			int relCount = rand.Next(2, (int)Math.Sqrt(nodeCount));
			while(currentNode <= (int)(nodeCount / 2))
			{
				nodeRelationshipList.Add(new Relationship { start = currentNode, end = endNode, distance = rand.Next(2,20) });

				//Lowest: 2 
				//Highest: root(total)
				if (rand.Next(2, (int)Math.Sqrt(nodeCount)) < (endNode - currentNode))
				{
					currentNode++;
					endNode = currentNode + 1;
				}
				else
					endNode++;
			}

			return nodeRelationshipList;
		}
		public struct Relationship {
			public int start;
			public int end;
			public int distance; 
		}

	}
}
