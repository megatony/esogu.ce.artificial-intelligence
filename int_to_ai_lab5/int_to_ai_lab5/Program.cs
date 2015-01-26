using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace int_to_ai_lab5
{
    public class Edge
    {
        public string name { get; set; }
        public List<Edge> neighbourEdges = new List<Edge>();
        public int f_value { get; set; }
        public int g_value { get; set; }
        public int h_value { get; set; }
        public Edge pre_node { get; set; }
    }
    
    class Program
    {
        public static List<Edge> path = new List<Edge>();
        public static List<Edge> graph = new List<Edge>();

        public static void ManhattanVisit(Edge u)
        {
            u.f_value = u.g_value + u.h_value;
            foreach (Edge v in u.neighbourEdges)
            {
                v.f_value = v.g_value + v.h_value;             
            }
            if (!(u.h_value == 0))
            {
                Console.WriteLine("Visited " + u.name);
                u.neighbourEdges = u.neighbourEdges.OrderBy(x => x.f_value).ToList();
                path.Add(u.neighbourEdges[0]);
                u.neighbourEdges[0].g_value = u.g_value + u.neighbourEdges[0].g_value;
                ManhattanVisit(u.neighbourEdges[0]);
            }
            else
            {
                Console.WriteLine("Finished");
            }
           
            
        }


        static void Main(string[] args)
        {
            Edge a = new Edge();
            Edge b = new Edge();
            Edge c = new Edge();
            Edge d = new Edge();
            Edge e = new Edge();
            Edge f = new Edge();
            Edge g = new Edge();
            Edge s = new Edge();

            a.name = "A";
            b.name = "B";
            c.name = "C";
            d.name = "D";
            g.name = "END";
            s.name = "START";

            s.neighbourEdges.Add(a);
            s.neighbourEdges.Add(g);

            s.neighbourEdges[0].g_value = 1;
            s.neighbourEdges[1].g_value = 12;

            a.neighbourEdges.Add(b);
            a.neighbourEdges.Add(c);

            a.neighbourEdges[0].g_value = 3;
            a.neighbourEdges[1].g_value = 1;
            
            b.neighbourEdges.Add(d);

            b.neighbourEdges[0].g_value = 3;

            c.neighbourEdges.Add(d);
            c.neighbourEdges.Add(g);

            c.neighbourEdges[0].g_value = 1;
            c.neighbourEdges[1].g_value = 2;

            d.neighbourEdges.Add(g);

            d.neighbourEdges[0].g_value = 3;

            graph.Add(s);
            graph.Add(a);
            graph.Add(b);
            graph.Add(c);
            graph.Add(d);
            graph.Add(g);

            s.h_value = 4;
            a.h_value = 2;
            b.h_value = 6;
            c.h_value = 2;
            d.h_value = 3;
            g.h_value = 0;


            ManhattanVisit(a);

        }

        
    }

    
}
