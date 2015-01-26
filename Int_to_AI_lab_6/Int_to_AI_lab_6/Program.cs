using System;
using System.Collections.Generic;
using System.Linq;
namespace Int_to_AI_lab_6
{
    class Program
    {
        static Random random;
        public static int backstate;
        public static int a, b, c = 0;
        static void Main(string[] args)
        {
                random = new Random(0);
                
                int[] problemData = CreateInitialSolution(4);
                int[] nbrState;
                int nbrCost;
                int[] state = RandomState(problemData);
                int cost = Cost(state, problemData);
                int[] bestState = state;
                int bestCost = cost;

                int iteration = 0;
                int maxIteration = 10000;
                double currTemp = 10000.0;
                double alpha = 0.995;

                Console.WriteLine("\nInitial state:");
                Display(problemData);

                Console.WriteLine("\nNext state:");
                Display(state);
                Console.WriteLine("Initial cost: " + (cost).ToString());
                Console.WriteLine("Initial temperature = " + currTemp.ToString() + "\n");


                while (iteration < maxIteration && currTemp > 0.0001)
                {
                    nbrState = NeighborState(state, problemData);
                    nbrCost = Cost(nbrState, problemData);

                    if (nbrCost < bestCost)
                    {
                        bestState = nbrState.Clone() as int[];
                        bestCost = nbrCost;
                        Console.WriteLine("New best state found:");
                        Display(bestState);
                        Console.WriteLine("Cost = " + bestCost.ToString() + "\n");
                    }

                    double p = random.NextDouble();

                    if (AcceptanceProb(cost, nbrCost, currTemp) > p)
                    {
                        state = nbrState.Clone() as int[];
                        cost = nbrCost;
                    }

                    currTemp = currTemp * alpha;
                    ++iteration;
                    Console.WriteLine("at iteration " + iteration);
                    Console.WriteLine("Simulated Annealing loop complete");
                    Console.WriteLine("\nBest state found:");
                    Display(bestState);
                    Console.WriteLine("Best cost = " + bestCost.ToString() + "\n");

                    Interpret(bestState, problemData);
                   
                }
                Console.WriteLine("\nEnd\n");
        } 
        static int[] CreateInitialSolution(int len)
        {
            int[] result = new int[len];
            result[0] = 1; 
            result[1] = 2;
            result[2] = -1;
            result[3] = 3;     
            return result;
        }
        static int[] RandomState(int[] problemData)
        {
            return Shuffle(problemData);           
        }

        public static int[] Shuffle(int[] _array)
        {
            Random _random = new Random();
            var random = _random;
            int[] array = new int[_array.Length];
            _array.CopyTo(array, 0);
            for (int i = array.Length; i > 1; i--)
            {
                // Pick random element to swap.
                int j = random.Next(i); // 0 <= j <= i-1
                // Swap.
                int tmp = array[j];
                array[j] = array[i - 1];
                array[i - 1] = tmp;
            }
            if (array == _array)
            {
                return Shuffle(array);
            }
            return array;
        }
        

        static int[] NeighborState(int[] currState, int[] problemData)
        {
            int[] result = new int[currState.Length];
            currState.CopyTo(result, 0);
            for (int i = 1; i < result.Length; i++)
            {
                int tmp = result[i];
                result[i] = result[i - 1];
                result[i - 1] = tmp;
            }
            return result;

           
        }
        static int Cost(int[] state, int[] problemData)
        {
            int result1 = 0;
            int result2 = 0;
            bool flag = true;
            for (int i = 0; i < state.Length; i++)
            {
                if (!(state[0] == -1) && flag)
                {
                    if (state[i] == 1)
                    {
                        result1 += 10;
                        a = 1;
                    }
                    else if (state[i] == 2)
                    {
                        result1 += 4;
                        b = 1;
                    }
                    else if (state[i] == 3)
                    {
                        result1 += 8;
                        c = 1;
                    }
                    if (backstate == 1)
                    {
                        if (state[i] == 2)
                        {
                            result1 += 4;
                        }
                        else if (state[i] == 3)
                        {
                            result1 += 10;
                        }
                    }
                    if (backstate == 2)
                    {
                        if (state[i] == 1)
                        {
                            result1 += 4;
                        }
                        else if (state[i] == 3)
                        {
                            result1 += 8;
                        }
                    }
                    if (backstate == 3)
                    {
                        if (state[i] == 1)
                        {
                            result1 += 6;
                        }
                        else if (state[i] == 2)
                        {
                            result1 += 10;
                        }
                    }
                    if (a == 1)
                    {
                        backstate = 1;
                    }
                    else if (b == 1)
                    {
                        backstate = 2;
                    }
                    else if( c==1)
                    {
                        backstate = 3;
                    }
                }
                else
                {
                    flag = false;

                    if (state[i] == 1)
                    {
                        result1 += 12;
                        a = 1;
                    }
                    else if (state[i] == 2)
                    {
                        result1 += 9;
                        b = 1;
                    }
                    else if (state[i] == 3)
                    {
                        result1 += 5;
                        c = 1;
                    }


                    if (backstate == 1)
                    {
                        if (state[i] == 2)
                        {
                            result2 += 4;
                        }
                        else if (state[i] == 3)
                        {
                            result2 += 10;
                        }
                    }
                    if (backstate == 2)
                    {
                        if (state[i] == 1)
                        {
                            result2 += 4;
                        }
                        else if (state[i] == 3)
                        {
                            result2 += 8;
                        }
                    }
                    if (backstate == 3)
                    {
                        if (state[i] == 1)
                        {
                            result2 += 6;
                        }
                        else if (state[i] == 2)
                        {
                            result2 += 10;
                        }
                    }
                    if (a == 1)
                    {
                        backstate = 1;
                    }
                    else if (b == 1)
                    {
                        backstate = 2;
                    }
                    else if (c == 1)
                    {
                        backstate = 3;
                    }
                }
            }
            if (result1 < result2)
            {
                return result1;
            }
            else
            {
                return result2;
            }
        }


        static bool ArraysEqual(int[] a1, int[] a2)
        {
            if (ReferenceEquals(a1, a2))
                return true;

            if (a1 == null || a2 == null)
                return false;

            if (a1.Length != a2.Length)
                return false;

            EqualityComparer<int> comparer = EqualityComparer<int>.Default;
            for (int i = 0; i < a1.Length; i++)
            {
                if (!comparer.Equals(a1[i], a2[i])) return false;
            }
            return true;
        }

        static double AcceptanceProb(double cost, double nbrCost, double currTemp)
        {
            if (nbrCost < cost)
                return 1.0;
            else
                return Math.Exp((cost - nbrCost) / currTemp);
        }
        
        static void Display(int[] vector)
        {
            for (int i = 0; i < vector.Length; ++i)
                Console.Write(vector[i] + " ");
            Console.WriteLine("");
        }
        static void Interpret(int[] state, int[] problemData)
        {
            for (int t = 0; t < state.Length; ++t)
            { 
                int w = state[t]; 
                Console.WriteLine(w);
            }
        }
    } 
} 