using System;
using System.Collections.Generic;
using System.Text;

namespace Graph_theory
{
    public class Edge
    {
        private int from;
        private int to;
        private int weight;
        public int From
        {
            get { return from; }
            private set { from = value; }
        }
        public int To
        {
            get { return to; }
            private set { to = value; }
        }
        public int Weight
        {
            get { return weight; }
            private set { weight = value; }
        }
        public Edge(int from, int to, int weight)
        {
            this.from = from;
            this.to = to;
            this.weight = weight;
        }
        public Edge(int from, int to)
        {
            this.from= from;
            this.to= to;
            this.weight = 1;
        }
        public Edge Clone()
        {
            return new Edge(from, to, weight);
        }
        public void ToString()
        {
            Console.WriteLine($"{From} --({Weight})--> {To}");
        }
    }
}
