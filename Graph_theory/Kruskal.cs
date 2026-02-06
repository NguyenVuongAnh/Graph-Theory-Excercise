using System;
using System.Collections.Generic;
using System.Text;

namespace Graph_theory
{
    internal class Kruskal
    {
        private int[] rank;
        private int[] parent;
        private List<Edge> mst = new List<Edge>();
        public List<Edge> MST
        {
            get { return mst; } 
        }
        private int mst_weight;
        public int MST_weight
        {
            get { return mst_weight; }
        }
        public Kruskal(AdjcencyMatrixGraph g_matrix)
        {
            rank = new int[g_matrix.N];
            parent = new int[g_matrix.N];
            for (int i = 0; i < g_matrix.N; i++)
            {
                parent[i] = i;
            }
            this.kruskal(Transform.Matrix_to_EdgeList(g_matrix));
        }
        public Kruskal(EdgeListGraph g_edgeList)
        {
            rank = new int[g_edgeList.N];
            parent = new int[g_edgeList.N];
            for (int i = 0; i < g_edgeList.N; i++)
            {
                parent[i] = i;
            }
            this.kruskal(g_edgeList);
        }
        public Kruskal(AdjcencyListGraph g_adjList)
        {
            rank = new int[g_adjList.N];
            parent = new int[g_adjList.N];
            for (int i = 0; i < g_adjList.N; i++)
            {
                parent[i] = i;
            }
            this.kruskal(Transform.AdjList_to_EdgeList(g_adjList));
        }
        public void kruskal(EdgeListGraph g_edgeList)
        {
            bool check = true;

            while (check)
            {
                check = false;

                for (int i = 0; i < g_edgeList.N - 1; i++)
                {
                    if (g_edgeList.Edges[i].Weight > g_edgeList.Edges[i + 1].Weight)
                    {
                        Edge tempEdge = g_edgeList.Edges[i].Clone();
                        g_edgeList.Edges[i] = g_edgeList.Edges[i + 1].Clone();
                        g_edgeList.Edges[i + 1] = tempEdge.Clone();

                        check = true;
                    }
                }
            }
            foreach(Edge edge in g_edgeList.Edges)
            {
                if(union(edge.To, edge.From))
                {
                    mst.Add(edge);
                    mst_weight += edge.Weight;
                }
            }
            for (int i = 0;i < mst.Count; i++)
            {
                mst[i].ToString();
            }
            Console.WriteLine($"w={mst_weight}");
        }
        private int find(int x)
        {
            if (parent[x] != x)
            {
                parent[x] = find(parent[x]);
            }
            return parent[x];
        }
        private bool union(int x, int y)
        {
            int root_x = find(x);
            int root_y = find(y);
            if (root_x == root_y)
            {
                return false;
            }
            if (rank[root_x] < rank[root_y])
            {
                parent[root_x] = root_y;
            }
            else if (rank[root_x] > rank[root_y])
            {
                parent[root_y] = root_x;
            }
            else
            {
                parent[root_y] = root_x;
                rank[root_x]++;
            }
            return true;
        }
    }
}
