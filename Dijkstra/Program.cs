using DijkstraAlgorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph();
            g.GetTopGraphs(@"C:\Users\Admin\source\repos\Dijkstra\Dijkstra\Data\File.txt");
            var result = g.Disjkstra(5, 100);
        }
    }
}
