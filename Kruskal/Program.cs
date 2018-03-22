using KruskalLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruskal
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph(@"c:\users\admin\source\repos\Kruskal\Kruskal\Data\File.txt");
            Array.Sort(g.edges);
            g.KrusKal();
        }
    }
}
