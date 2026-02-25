using System;
using System.Collections.Generic;
using System.Text;

namespace Graph_theory
{
    public class Floyd
    {
        private int[,] next;
        private int[,] dist;
        public Floyd() { }
        public void floyd(AdjcencyMatrixGraph g)
        {
            next = new int[g.N,g.N];
            dist = new int[g.N, g.N];
            for (int i=0; i<g.N; i++)
            {
                for(int j=0; j<g.N; j++)
                {
                    if (g.Matrix[i,j] != int.MaxValue)
                    {
                        next[i, j] = j;
                        dist[i, j] = g.Matrix[i, j];
                    }
                    else
                    {
                        next[i, j] = -1;
                        dist[i, j] = int.MaxValue;
                    }
                }
            }
            for (int k=0; k<g.N; k++)
            {
                for (int i=0; i<g.N; i++)
                {
                    for (int j = 0; j < g.N; j++)
                    {
                        int l = dist[i, k] + dist[k, j];
                        if (dist[i,k]!=int.MaxValue && dist[k,j]!=int.MaxValue && l < dist[i, j])
                        {
                            dist[i, j] = l;
                            next[i, j] = next[i, k];
                        }
                    }
                }
            }
        }
        public void floyd(AdjcencyMatrixGraph g, bool show_path = false)
        {
            next = new int[g.N, g.N];
            dist = new int[g.N, g.N];
            for (int i = 0; i < g.N; i++)
            {
                for (int j = 0; j < g.N; j++)
                {
                    if (g.Matrix[i, j] != int.MaxValue)
                    {
                        next[i, j] = j;
                        dist[i, j] = g.Matrix[i, j];
                    }
                    else
                    {
                        next[i, j] = -1;
                        dist[i, j] = int.MaxValue;
                    }
                }
            }
            for (int k = 0; k < g.N; k++)
            {
                Console.WriteLine($"k = {k}");
                for (int i = 0; i < g.N; i++)
                {
                    for (int j = 0; j < g.N; j++)
                    {
                        int l = dist[i, k] + dist[k, j];
                        if (dist[i, k] != int.MaxValue && dist[k, j] != int.MaxValue && l < dist[i, j])
                        {
                            Console.WriteLine($"Update: dist[{i}, {j}] = {l} via {k}");
                            dist[i, j] = l;
                            next[i, j] = next[i, k];
                        }
                    }
                }
            }
        }
        public void printPath(int i, int j)
        {
            Console.WriteLine($"Distance i to j: {dist[i, j]}");
            if (next[i,j] != -1)
            {
                Console.Write($"{i} ");
                while (i != j)
                {
                    i = next[i, j];
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
