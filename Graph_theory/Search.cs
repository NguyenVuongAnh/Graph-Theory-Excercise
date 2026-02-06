using System;
using System.Collections.Generic;
using System.Text;

namespace Graph_theory
{
    internal class Search
    {
        public static void DFS(AdjcencyMatrixGraph g_matrix, int vertex, bool[] visited)
        {
            visited[vertex] = true;
            Console.Write($"{vertex} ");
            for (int j = 0; j < g_matrix.N; j++)
            {
                if (visited[j] == false && g_matrix.Matrix[vertex, j] != 0)
                {
                    DFS(g_matrix, j, visited);
                }
            }
        }
        public static void DFS(EdgeListGraph g_edgeList, int vertex, bool[] visited)
        {
            visited[vertex] = true;
            Console.Write($"{vertex} ");
            foreach (Edge edge in g_edgeList.Edges)
            {
                if (edge.From == vertex && visited[edge.To] == false)
                {
                    DFS(g_edgeList, edge.To, visited);
                }
            }
        }
        public static void DFS(AdjcencyListGraph g_adjList, int vertex, bool[] visited)
        {
            visited[vertex] = true;
            Console.Write($"{vertex} ");
            foreach ((int To, int Weight) in g_adjList.Adj[vertex])
            {
                if (visited[To] == false)
                {
                    DFS(g_adjList, To, visited);
                }
            }
        }

        public static void DFS_stack(AdjcencyMatrixGraph g_matrix, int start)
        {
            bool[] bools = new bool[g_matrix.N];
            Stack<int> stack = new Stack<int>();
            stack.Push(start);
            while (stack.Count != 0)
            {
                int vertex = stack.Pop();
                if (bools[vertex] == false)
                {
                    Console.Write($"{vertex} ");
                    bools[vertex] = true;
                    for (int j = g_matrix.N - 1; j >= 0; j--)
                    {
                        if (g_matrix.Matrix[vertex, j] != 0 && bools[j] == false)
                        {
                            stack.Push(j);
                        }
                    }
                }
            }
            Console.WriteLine();
        }
        public static void DFS_stack(EdgeListGraph g_edgeList, int start)
        {
            bool[] bools = new bool[g_edgeList.N];
            Stack<int> stack = new Stack<int>();
            stack.Push(start);
            while (stack.Count != 0)
            {
                int vertex = stack.Pop();
                if (bools[vertex] == false)
                {
                    Console.Write($"{vertex} ");
                    bools[vertex] = true;
                    for (int i = g_edgeList.Edges.Count - 1; i >= 0; i--)
                    {
                        if (g_edgeList.Edges[i].From == vertex && bools[g_edgeList.Edges[i].To] == false)
                        {
                            stack.Push(g_edgeList.Edges[i].To);
                        }
                    }
                }
            }
            Console.WriteLine();
        }
        public static void DFS_stack(AdjcencyListGraph g_adjList, int start)
        {
            bool[] bools = new bool[g_adjList.N];
            Stack<int> stack = new Stack<int>();
            stack.Push(start);
            while (stack.Count != 0)
            {
                int vertex = stack.Pop();
                if (bools[vertex] == false)
                {
                    Console.Write($"{vertex} ");
                    bools[vertex] = true;
                    for (int j = g_adjList.Adj[vertex].Count - 1; j >= 0; j--)
                    {
                        if (bools[g_adjList.Adj[vertex][j].Item1] == false)
                        {
                            stack.Push(g_adjList.Adj[vertex][j].Item1);
                        }
                    }
                }
            }
            Console.WriteLine();
        }

        public static void BFS(AdjcencyMatrixGraph g_matrix, int start)
        {
            bool[] bools = new bool[g_matrix.N];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            bools[start] = true;
            while (queue.Count != 0)
            {
                int vertex = queue.Dequeue();
                Console.Write($"{vertex} ");
                for (int j = 0; j < g_matrix.N; j++)
                {
                    if (g_matrix.Matrix[vertex, j] != 0 && bools[j] == false)
                    {
                        queue.Enqueue(j);
                        bools[j] = true;
                    }
                }
            }
            Console.WriteLine();
        }
        public static void BFS(EdgeListGraph g_edgeList, int start)
        {
            bool[] bools = new bool[g_edgeList.N];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            bools[start] = true;
            while (queue.Count != 0)
            {
                int vertex = queue.Dequeue();
                Console.Write($"{vertex} ");
                foreach (Edge edge in g_edgeList.Edges)
                {
                    if (edge.From == vertex && bools[edge.To] == false)
                    {
                        queue.Enqueue(edge.To);
                        bools[edge.To] = true;
                    }
                }
            }
            Console.WriteLine();
        }
        public static void BFS(AdjcencyListGraph g_adjList, int start)
        {
            bool[] bools = new bool[g_adjList.N];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            bools[start] = true;
            while (queue.Count != 0)
            {
                int vertex = queue.Dequeue();
                Console.Write($"{vertex} ");
                foreach((int To, int Weight) in g_adjList.Adj[vertex])
                {
                    if (bools[To] == false)
                    {
                        queue.Enqueue(To);
                        bools[To] = true;
                    }
                }
            }
            Console.WriteLine();
        }
    }
}