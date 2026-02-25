using Graph_theory;

namespace Graph_theory
{
    class Program
    {
        public static void Main(string[] args)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine(basePath);


            AdjcencyMatrixGraph g_matrix = new AdjcencyMatrixGraph(7);
            g_matrix.Read(Path.Combine(basePath, "Newfolder\\AdjMatrix.txt"));
            Floyd floyd = new Floyd();
            floyd.floyd(g_matrix, false);
            floyd.printPath(5, 10);
            //g_matrix.ToString();
            /*bool[] bools = new bool[7];
            
            Search.DFS(g_matrix, 6, bools);
            
            Console.WriteLine();
            Search.DFS_stack(g_matrix, 6);*/


            /*bools = new bool[7];
            EdgeListGraph edgeListGraph = Transform.Matrix_to_EdgeList(g_matrix);
            //edgeListGraph.ToString();
            
            Search.DFS(edgeListGraph, 6, bools);
            
            Console.WriteLine();
            Search.DFS_stack(edgeListGraph, 6);
            Kruskal kruskal = new Kruskal(edgeListGraph);
            Dijkstra dijkstra = new Dijkstra(edgeListGraph);
            dijkstra.dijkstra(5);
            dijkstra.ToString();

            bools = new bool[7];
            AdjcencyListGraph adjcencyListGraph = Transform.Matrix_to_AdjList(g_matrix);
            //adjcencyListGraph.ToString();
            
            Search.DFS(adjcencyListGraph, 6, bools);
            
            Console.WriteLine();
            Search.DFS_stack(adjcencyListGraph, 6);


            Search.BFS(g_matrix, 6);
            Search.BFS(edgeListGraph, 6);
            Search.BFS(adjcencyListGraph, 6);*/


            /*EdgeListGraph g_edgeList = new EdgeListGraph();
            g_edgeList.Read(Path.Combine(basePath, "NewFolder\\EdgeList.txt"));
            g_edgeList.ToString();
            AdjcencyMatrixGraph adjcencyMatrixGraph = Transform.EdgeList_to_Matrix(g_edgeList);
            adjcencyMatrixGraph.ToString();
            AdjcencyListGraph adjcencyListGraph = Transform.EdgeList_to_AdjList(g_edgeList);
            adjcencyListGraph.ToString();

            AdjcencyListGraph g_adjList = new AdjcencyListGraph();
            g_adjList.Read(Path.Combine(basePath, "NewFolder\\AdjcencyList.txt"));
            g_adjList.ToString();
            AdjcencyMatrixGraph adjcencyMatrixGraph = Transform.AdjList_to_Matrix(g_adjList);
            adjcencyMatrixGraph.ToString();
            EdgeListGraph edgeListGraph = Transform.AdjList_to_EdgeList(g_adjList);
            edgeListGraph.ToString();*/
        }
    }
}