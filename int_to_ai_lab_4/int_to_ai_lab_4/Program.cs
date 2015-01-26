using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace int_to_ai_lab_4
{
    public class Color
    {
        public string name { get; set; }
    }

    public class Edge
    {
        public string name { get; set; }
        public Color color = new Color();
        public List<Edge> neighbourEdges = new List<Edge>();
        public Edge pred { get; set; }
    }
    
    class Program
    {
        public static List<Edge> graph = new List<Edge>();
        public static Stack<Edge> stack = new Stack<Edge>();
        public static int time = 0;
        public static List<int> d = new List<int>();
        public static List<int> f = new List<int>();
        static void Main(string[] args)
        {
            CreateGraph();
            foreach (Edge u in graph)
            {
                u.color.name = "white";
                u.pred = null;
                stack.Push(u);
            }
            time = 0;
            foreach (Edge u in graph)
            {
                if (u.color.name == "white")
                {
                    DFSVisit(u);
                    
                }

            }
            
        }
        public static void CreateGraph() 
        {

            Edge a = new Edge();
            Edge b = new Edge();
            Edge c = new Edge();
            Edge d = new Edge();
            Edge e = new Edge();
            Edge f = new Edge();
            Edge g = new Edge();
            Edge h = new Edge();

            graph.Add(a);
            graph.Add(b);
            graph.Add(c);
            graph.Add(d);
            graph.Add(e);
            graph.Add(f);
            graph.Add(g);
            graph.Add(h);

            a.name = "a";
            b.name = "b";
            c.name = "c";
            d.name = "d";
            e.name = "e";
            f.name = "f";
            g.name = "g";
            h.name = "h";

            a.neighbourEdges.Add(b);
            a.neighbourEdges.Add(c);
            a.neighbourEdges.Add(e);

            b.neighbourEdges.Add(a);
            b.neighbourEdges.Add(d);
            b.neighbourEdges.Add(f);

            c.neighbourEdges.Add(a);
            c.neighbourEdges.Add(d);
            c.neighbourEdges.Add(f);
            c.neighbourEdges.Add(g);
            

            d.neighbourEdges.Add(b);
            d.neighbourEdges.Add(c);
            d.neighbourEdges.Add(e);
            d.neighbourEdges.Add(h);

            e.neighbourEdges.Add(a);
            e.neighbourEdges.Add(d);
            e.neighbourEdges.Add(f);
            e.neighbourEdges.Add(g);
            
            

            f.neighbourEdges.Add(b);
            f.neighbourEdges.Add(c);
            f.neighbourEdges.Add(e);
            f.neighbourEdges.Add(h);
            

            g.neighbourEdges.Add(c);
            g.neighbourEdges.Add(e);
            g.neighbourEdges.Add(h);

            h.neighbourEdges.Add(d);
            h.neighbourEdges.Add(f);
            h.neighbourEdges.Add(g);
        }
        public static void DFSVisit(Edge u)
        {
            u.color.name = "gray";
            d.Add(++time);
            Console.WriteLine("Visited " + u.name);
            foreach (Edge v in u.neighbourEdges)
            {
                if (v.color.name == "white")
                {
                    u.pred = v;
                    DFSVisit(v);
                }
            }
            u.color.name = "black";
            f.Add(++time);
            if (!(stack.Count == 0))
            {
                stack.Pop();
            }
            else
            {
                Console.WriteLine("Finished.");
            }
        }
    }
    
}
