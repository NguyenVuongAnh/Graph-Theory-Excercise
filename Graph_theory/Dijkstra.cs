using System;
using System.Collections.Generic;
using System.Text;

namespace Graph_theory
{
    internal class Dijkstra
    {
        private AdjcencyListGraph g_adjList;
        private int n = 0;
        private int[] distance;
        private int[] parent;
        public Dijkstra(AdjcencyMatrixGraph g_matrix)
        {
            n = g_matrix.N;
            distance = new int[n];
            parent = new int[n];
            for (int i = 0; i < n; i++)
            {
                distance[i] = int.MaxValue;
                parent[i] = -1;
            }
            this.g_adjList = Transform.Matrix_to_AdjList(g_matrix);
        }
        public Dijkstra(EdgeListGraph g_edgeList)
        {
            n = g_edgeList.N;
            distance = new int[n];
            parent = new int[n];
            for (int i = 0; i < n; i++)
            {
                distance[i] = int.MaxValue;
                parent[i] = -1;
            }
            this.g_adjList = Transform.EdgeList_to_AdjList(g_edgeList);
        }
        public Dijkstra( AdjcencyListGraph g_adjList)
        {
            n = g_adjList.N;
            distance = new int[n];
            parent = new int[n];
            for (int i = 0; i < n; i++)
            {
                distance[i] = int.MaxValue;
                parent[i] = -1;
            }
            this.g_adjList = g_adjList;
        }
        public void dijkstra(int start)
        {
            bool[] visited = new bool[n];
            distance[start] = 0;

            for (int i = 0; i < n; i++)
            {
                int u = -1;
                int minDist = int.MaxValue;

                for (int j = 0; j < n; j++)
                {
                    if (!visited[j] && distance[j] < minDist)
                    {
                        minDist = distance[j];
                        u = j;
                    }
                }

                if (u == -1) break;

                visited[u] = true;
                foreach (var edge in g_adjList.Adj[u])
                {
                    int v = edge.Item1;
                    int w = edge.Item2;

                    if (!visited[v] && distance[u] != int.MaxValue &&
                        distance[u] + w < distance[v])
                    {
                        distance[v] = distance[u] + w;
                        parent[v] = u;
                    }
                }
            }
        }
        public void ToString()
        {
            for (int i = 0; i<n; i++)
            {
                Console.Write($"{i}|{parent[i]}|{distance[i]}, ");
            }
            Console.Write('\n');
        }
    }
}
