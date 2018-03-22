﻿using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DijkstraAlgorithm
{
    
    public class TopGraph
    {
        public class Point
        {
            private double x;
            private double y;

            public double X { get => x; set => x = value; }
            public double Y { get => y; set => y = value; }

            public Point()
            {

            }
            public Point(double x,double y )
            {
                this.X = x;
                this.Y = y;
            }
        }
        private int id;
        private Point getPoints;
        private string name;
        private Hashtable pointNeighbour;
        private int numOfNeighbour;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public Point GetPoints { get => getPoints; set => getPoints = value; }
        public Hashtable PointNeighbour { get => pointNeighbour; set => pointNeighbour = value; }
        public int NumOfNeighbour { get => numOfNeighbour; set => numOfNeighbour = value; }

        public TopGraph()
        {

            pointNeighbour = new Hashtable();
        }

        public TopGraph(int id, Point point, string name, Hashtable list, int numOfNeighbour)
        {
            this.Id = id;
            this.GetPoints = point;
            this.PointNeighbour = list;
            this.NumOfNeighbour = numOfNeighbour;
        }

        public bool JsonToFile(string pathFileText, string pathFileout)
        {
            try
            {
                var list = ConvertTextToList(pathFileText);
                if (File.Exists(pathFileout))
                {
                    File.WriteAllText(pathFileout, JsonConvert.SerializeObject(list));

                    return true;
                }
                using (StreamWriter files = File.CreateText(pathFileout))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    //serialize object directly into file stream
                    serializer.Serialize(files, list);
                    files.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public List<TopGraph> ConvertTextToList(string path)
        {
            try
            {
                var r = new bool[10];
                string line;
                List<TopGraph> list = new List<TopGraph>();
                using (StreamReader file = new StreamReader(path))
                {
                    int count = 0;
                    while ((line = file.ReadLine()) != null)
                    {
                        TopGraph topGraph = new TopGraph();
                        topGraph.Id = count;
                        var data = line.Split(' ');
                        var num = int.Parse(data[0]);
                        for (int i = 1; i <= num * 2; i++)
                        {
                            if (i + 1 <= num * 2)
                            {
                                topGraph.PointNeighbour.Add(int.Parse(data[i]), double.Parse(data[i + 1]));
                                //topGraph.PointNeighbour.Add(item);
                            }
                            i++;
                        }
                        StringBuilder builder = new StringBuilder();
                        for (int j = num * 2 + 1; j < data.Length - 2; j++)
                        {
                            builder.Append(data[j]);
                            builder.Append(" ");
                        }
                        topGraph.NumOfNeighbour = topGraph.PointNeighbour.Count;
                        topGraph.Name = builder.ToString().Trim();
                        topGraph.GetPoints = new Point(double.Parse(data[data.Length - 2]), double.Parse(data[data.Length - 1]));
                        count++;
                        list.Add(topGraph);
                    }
                    file.Close();
                }
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
