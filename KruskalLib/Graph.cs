using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace KruskalLib
{

    public class Graph
    {

        public int V;
        public int E;
        public Edge[] edges;

        public int[] root;

        public class Edge : IComparable<Edge>
        {

            public int src;
            public int dest;
            public int w;

            public Edge(int src, int dest, int w)
            {
                this.dest = dest;
                this.src = src;
                this.w = w;
            }

            public Edge()
            {

            }


            public int CompareTo(Edge other)
            {
                return this.w.CompareTo(other.w);
            }
        }

        /// <summary>
        /// Create a graph with file input 
        /// </summary>
        /// <param name="file"></param>
        public Graph(string file)
        {
            try
            {
                string line = null;
                using (StreamReader reader = new StreamReader(file))
                {
                    line = reader.ReadLine();
                    string[] V_E = line.Split(' ');

                    this.V = int.Parse(V_E[0]);
                    this.E = int.Parse(V_E[1]);
                    string[] e = null;
                    List<Edge> list = new List<Edge>();

                    for (int j = 0; j < E; j++)
                    {
                        line = reader.ReadLine();
                        e = line.Split(' ');
                        Edge edge = new Edge(int.Parse(e[0]), int.Parse(e[1]), int.Parse(e[2]));
                        list.Add(edge);
                    }
                    edges = list.ToArray();
                    Array.Sort(edges);
                    reader.Close();
                }
            }
            catch (IOException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Write to file a array 
        /// </summary>
        /// <param name="path"></param>
        public void WriteFile(string path)
        {
            Array.Sort(edges);
            using (StreamWriter files = File.CreateText(path))
            {
                for (int i = 0; i < edges.Length; i++)
                {
                    files.WriteLine(edges[i].src + " " + edges[i].dest + " " + edges[i].w);
                }
                files.Close();
            }
        }


        public void CreateRoot(int num)
        {
            root = new int[num];
            for (int i = 0; i < num; i++)
            {
                root[i] = -1;
            }
        }

        public int FindRoot(int[] r, int v)
        {
            if (root[v] == -1)
            {
                return v;
            }
            return FindRoot(r, r[v]);
        }

        public void Union(int x, int y)
        {
            int xRoot = FindRoot(root, x);
            int yRoot = FindRoot(root, y);
            root[xRoot] = yRoot;
        }

        /// <summary>
        /// Kruskal's algorithm
        /// </summary>
        public void KrusKal()
        {
            CreateRoot(E);
            foreach (Edge edge in edges)
            {

                if (FindRoot(root, edge.src) == FindRoot(root, edge.dest))
                {
                    Debug.WriteLine("Can't draw a line from " + edge.src + " to " + edge.dest);
                    Console.WriteLine ("Can't draw a line from " + edge.src + " to " + edge.dest);
                }
                else
                {
                    Debug.WriteLine("Can draw a line from " + edge.src + " to " + edge.dest);
                    Console.WriteLine ("Can draw a line from " + edge.src + " to " + edge.dest);
                    Union(edge.src, edge.dest);
                }

            }
        }
    }
}

