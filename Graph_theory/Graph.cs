using System;
using System.Collections.Generic;
using System.Text;

namespace Graph_theory
{
    public class AdjcencyMatrixGraph
    {
        private int n;
        private int m;
        private int[,] matrix;
        public int N
        {
            get { return n; }
            private set { n = value; }
        }
        public int M
        {
            get { return m; }
            private set { m = value; }
        }
        public int[,] Matrix
        {
            get
            {
                return matrix;
            }
            set
            {
                matrix = value; 
            }
        }
        public AdjcencyMatrixGraph(int n)
        {
            this.n = n;
            m = 0;
            matrix = new int[n, n];
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    matrix[i, j] = 0;
                }
            }
        }
        public void Read(string path)
        {
            StreamReader reader = new StreamReader(path);
            string line;
            n = int.Parse(reader.ReadLine());
            matrix = new int[n, n];
            int i = 0;
            while((line = reader.ReadLine()) != null)
            {
                string[] value = line.Split(' '); 
                for(int j = 0; j < value.Length; j++)
                {
                    matrix[i, j] = int.Parse(value[j]);
                    if (matrix[i,j]!= 0)
                    {
                        m++;
                    }
                }
                i++;
            }
            reader.Close();
        }
        public void Add(Edge edge)
        {
            if (matrix[edge.From, edge.To] == 0)
            {
                matrix[edge.From, edge.To] = edge.Weight;
                m++;
            }
            else
            {
                matrix[edge.From, edge.To] = edge.Weight;
            }
        }
        public void ToString()
        {
            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Node:{n}, Edge:{m}");
        }
    }
    public class EdgeListGraph
    {
        private int m;
        private int n;
        private List<Edge> edges = new List<Edge>();
        private List<int> vertices = new List<int>();
        public List<Edge> Edges
        {
            get { return edges; } 
        }
        public int N
        {
            get { return n; }
            private set { n = value; }
        }
        public int M
        {
            get { return m; } 
            private set { m = value; }
        }
        public EdgeListGraph()
        {
            edges = new List<Edge>();
            n = 0;
            m = 0;
        }
        public EdgeListGraph(Edge[] edges)
        {
            if(edges.Length == 0 || edges==null)
            {
                this.edges = new List<Edge>();
                n = 0;
                m = 0;
                return;
            }
            else
            {
                foreach (Edge edge in edges)
                {
                    this.Add(edge);
                }
            }
        }
        public void Add(Edge edge_add)
        {
            bool check = false;
            for(int i = 0; i < edges.Count; i++)
            {
                if (edge_add.From == edges[i].From & edge_add.To == edges[i].To)
                {
                    edges[i] = edge_add.Clone();
                    check = true;
                    break;
                }
            }
            if (!check)
            {
                edges.Add(edge_add);
                if (!vertices.Contains(edge_add.From))
                    vertices.Add(edge_add.From);

                if (!vertices.Contains(edge_add.To))
                    vertices.Add(edge_add.To);
                n = vertices.Count;
                vertices.Sort();
                m++;
            }
        }
        public void Read(string path)
        {
            StreamReader reader = new StreamReader(path);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[]  values = line.Split(' ');
                if(values.Length == 3)
                {
                    Edge edge = new Edge(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]));
                    this.Add(edge);
                }
                else
                {
                    Edge edge = new Edge(int.Parse(values[0]), int.Parse(values[1]));
                    this.Add(edge);
                }
            }
            reader.Close();
        }
        public void ToString()
        {
            foreach(Edge edge in edges)
            {
                edge.ToString();
            }
            Console.WriteLine($"n={n}, m={m}");
        }
    }
    public class AdjcencyListGraph
    {
        private Dictionary<int, List<(int, int)>> adj;
        private List<int> vertices;
        private int n;
        private int m;
        public Dictionary<int, List<(int, int)>> Adj
        {
            get { return adj; }
            set
            {
                adj = value; 
            }
        }
        public int N
        {
            get { return n; } 
        }
        public int M
        {
            get { return m; }
        }
        public AdjcencyListGraph()
        {
            adj = new Dictionary<int, List<(int ,int)>>();
            vertices = new List<int>();
            n = 0;
        }
        public void Add(Edge edge)
        {
            if (edge.Weight == 0) return;
            bool check = false;
            foreach( var key in adj.Keys)
            {
                if (key == edge.From)
                {
                    if (adj[key].Count == 0)
                    {
                        adj[key] = new List<(int ,int)>();
                    }
                    for(int i  = 0;  i < adj[key].Count; i++)
                    {
                        if (adj[key][i].Item1 == edge.To)
                        {
                            adj[key][i] = (edge.To,edge.Weight);
                            return;
                        }
                    }
                    adj[key].Add((edge.To, edge.Weight));
                    m++;
                    check = true;
                }
            }
            if (!check)
            {
                adj[edge.From] = new List<(int, int)>();
                adj[edge.From].Add((edge.To, edge.Weight));
                m++;
            }
            if (!vertices.Contains(edge.From))
            {
                vertices.Add(edge.From);
            }
            if (!vertices.Contains(edge.To))
            {
                vertices.Add(edge.To);
            }
            n = vertices.Count;
        }
        public void Read(string path)
        {
            StreamReader reader = new StreamReader(path);
            string line;
            while((line = reader.ReadLine()) != null)
            {
                string[] token = line.Split(' ');
                //foreach (string token2 in token)
                //{
                //    Console.Write($"{token2} ");
                //}
                //Console.WriteLine();
                for (int i = 1; i < token.Length; i = i + 2)
                {
                    //Console.Write($"{token[0]} {token[i]} {token[i+1]}  ");
                    this.Add(new Edge(int.Parse(token[0]), int.Parse(token[i]), int.Parse(token[i + 1])));
                }
                //Console.WriteLine();
            }
        }
        public void ToString()
        {
            foreach(int key in adj.Keys)
            {
                Console.Write($"{key}: ");
                foreach( (int To, int Weight) in adj[key])
                {
                    Console.Write($"({To}, {Weight}), ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"n={n}, m={m}");
        }
    }
}
