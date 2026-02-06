using System;
using System.Collections.Generic;
using System.Text;

namespace Graph_theory
{
    public class Transform
    {
        public static AdjcencyMatrixGraph EdgeList_to_Matrix(EdgeListGraph g_edgeList)
        {
            AdjcencyMatrixGraph g_matrix = new AdjcencyMatrixGraph(g_edgeList.N);
            foreach(Edge edge in g_edgeList.Edges)
            {
                g_matrix.Add(edge);
            }
            return g_matrix;
        }
        public static AdjcencyMatrixGraph AdjList_to_Matrix(AdjcencyListGraph g_adjList)
        {
            AdjcencyMatrixGraph g_matrix = new AdjcencyMatrixGraph(g_adjList.N);
            foreach (int key in g_adjList.Adj.Keys)
            {
                foreach ((int To, int Weight) in g_adjList.Adj[key])
                {
                    g_matrix.Add(new Edge(key ,To , Weight));
                }
            }
            return g_matrix;
        }

        public static EdgeListGraph Matrix_to_EdgeList(AdjcencyMatrixGraph g_matrix)
        {
            EdgeListGraph g_edgeList = new EdgeListGraph();
            int n = g_matrix.N;
            for(int i=0; i< n; i++)
            {
                for(int j=0; j< n; j++)
                {
                    if (g_matrix.Matrix[i, j] != 0)
                    {
                        g_edgeList.Add(new Edge(i, j, g_matrix.Matrix[i, j]));
                    }
                }
            }
            return g_edgeList;
        }
        public static EdgeListGraph AdjList_to_EdgeList(AdjcencyListGraph g_adjList)
        {
            EdgeListGraph g_edgeList = new EdgeListGraph();
            foreach( int key in g_adjList.Adj.Keys)
            {
                foreach((int To, int Weight) in g_adjList.Adj[key])
                {
                    g_edgeList.Add(new Edge(key, To , Weight));
                }
            }
            return g_edgeList;
        }

        public static AdjcencyListGraph Matrix_to_AdjList(AdjcencyMatrixGraph g_matrix)
        {
            AdjcencyListGraph g_adjList = new AdjcencyListGraph();
            int n = g_matrix.N;
            for(int i=0; i < n; i++)
            {
                for(int j=0; j< n; j++)
                {
                    g_adjList.Add(new Edge(i, j, g_matrix.Matrix[i, j]));
                }
            }
            return g_adjList;
        }
        public static AdjcencyListGraph EdgeList_to_AdjList(EdgeListGraph g_edgeList)
        {
            AdjcencyListGraph g_adjList = new AdjcencyListGraph();
            int n = g_edgeList.N;
            foreach(Edge edge in g_edgeList.Edges)
            {
                g_adjList.Add(edge);
            }
            return g_adjList;
        }
    }
}
