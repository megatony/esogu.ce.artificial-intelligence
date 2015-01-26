using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace int_to_ai_lab1
{

    static class Program
    {
        public class State
        {
            public string name { get; set; }
            public int[,] value { get; set; }
            public int manhattanValue { get; set; }
        }
        public static string akin;
        public static int step = 0;
        public static bool isok = false;
        static void Main(string[] args)
        {
            int[,] goal = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
            int[,] given = new int[,] { { 0, 1, 3 }, { 4, 2, 5 }, { 7, 8, 6 } };
            List<State> looked = new List<State>();
            
            while (!ContentEquals(given,goal))
            {
                for (int saydir = 0; saydir <= given.Rank; saydir++)
                {
                    for (int saydir2 = 0; saydir2 <= given.Rank; saydir2++)
                    {
                        if (given[saydir, saydir2] == 0)
                        {

                            //2 states
                            if ((saydir == 0 && saydir2 == 0))
                            {
                                State stateA = new State();
                                State stateB = new State();


                                stateA.value = given.Clone() as int[,];
                                stateB.value = given.Clone() as int[,];


                                stateA.value[0, 0] = given[0, 1];
                                stateA.value[0, 1] = given[0, 0];

                                stateB.value[0, 0] = given[1, 0];
                                stateB.value[1, 0] = given[0, 0];

                                stateA.manhattanValue = CalculateManhattan(stateA.value, goal, step);
                                stateB.manhattanValue = CalculateManhattan(stateB.value, goal, step);

                                State[] states = new State[] { stateA, stateB };

                                int[] sirala = {stateA.manhattanValue,
                                               stateB.manhattanValue};
                                BubbleSort(sirala);

                                foreach (var k in states)
                                {
                                    if (k.manhattanValue == sirala[0] && given != k.value && isok == false)
                                    {
                                        given = k.value.Clone() as int[,];
                                        step++;
                                        for (int a = 0; a <= given.Rank; a++)
                                        {
                                            
                                            for (int b = 0; b <= given.Rank; b++)
                                            {
                                                akin = akin + " " + given[a, b].ToString();
                                            }
                                            akin = akin + "\n";
                                        }
                                        akin = akin + "\n";
                                        isok = true;
                                    }
                                }
                                if (ContentEquals(given, goal))
                                {
                                    Console.WriteLine(akin + "Finished in " + step.ToString() + " steps");
                                    return;
                                }
                                isok = false;
                            }
                            else if ((saydir == 0 && saydir2 == 2))
                            {
                                State stateA = new State();
                                State stateB = new State();


                                stateA.value = given.Clone() as int[,];
                                stateB.value = given.Clone() as int[,];

                                stateA.value[0, 2] = given[1, 2];
                                stateB.value[0, 1] = given[0, 2];
                                stateA.value[1, 2] = given[0, 2];
                                stateB.value[0, 2] = given[0, 1];

                                stateA.manhattanValue = CalculateManhattan(stateA.value, goal, step);
                                stateB.manhattanValue = CalculateManhattan(stateB.value, goal, step);
                                int[] sirala = {stateA.manhattanValue,
                                               stateB.manhattanValue};
                                BubbleSort(sirala);
                                State[] states = new State[] { stateA, stateB };
                                foreach (var k in states)
                                {
                                    if (k.manhattanValue == sirala[0] && given != k.value && isok == false)
                                    {
                                        given = k.value.Clone() as int[,];
                                        step++;
                                        for (int a = 0; a <= given.Rank; a++)
                                        {
                                            for (int b = 0; b <= given.Rank; b++)
                                            {
                                                akin = akin + " " + given[a, b].ToString();
                                            }
                                            akin = akin + "\n";
                                        }
                                        akin = akin + "\n";
                                        isok = true;
                                    }
                                }
                                if (ContentEquals(given, goal))
                                {
                                    Console.WriteLine(akin + "Finished in " + step.ToString() + " steps");
                                    return;
                                }
                                isok = false;

                            }
                            else if ((saydir == 2 && saydir2 == 0))
                            {
                                State stateA = new State();
                                State stateB = new State();

                                stateA.value = given.Clone() as int[,];
                                stateB.value = given.Clone() as int[,];

                                stateA.value[1, 0] = given[2, 0];
                                stateB.value[2, 0] = given[2, 1];
                                stateA.value[2, 0] = given[1, 0];
                                stateB.value[2, 1] = given[2, 0];

                                stateA.manhattanValue = CalculateManhattan(stateA.value, goal, step);
                                stateB.manhattanValue = CalculateManhattan(stateB.value, goal, step);

                                int[] sirala = {stateA.manhattanValue,
                                               stateB.manhattanValue};
                                BubbleSort(sirala);
                                State[] states = new State[] { stateA, stateB };

                                foreach (var k in states)
                                {
                                    if (k.manhattanValue == sirala[0] && given != k.value && isok == false)
                                    {
                                        given = k.value.Clone() as int[,];
                                        step++;
                                        for (int a = 0; a <= given.Rank; a++)
                                        {
                                            for (int b = 0; b <= given.Rank; b++)
                                            {
                                                akin = akin + " " + given[a, b].ToString();
                                            }
                                            akin = akin + "\n";
                                        }
                                        akin = akin + "\n";
                                        isok = true;
                                    }
                                }
                                if (ContentEquals(given, goal))
                                {
                                    Console.WriteLine(akin + "Finished in " + step.ToString() + " steps");
                                    return;
                                }
                                isok = false;

                            }
                            else if ((saydir == 2 && saydir2 == 2))
                            {
                                State stateA = new State();
                                State stateB = new State();

                                stateA.value = given.Clone() as int[,];
                                stateB.value = given.Clone() as int[,];

                                stateA.value[2, 2] = given[1, 2];
                                stateB.value[2, 1] = given[2, 2];
                                stateA.value[1, 2] = given[2, 2];
                                stateB.value[2, 2] = given[2, 1];

                                stateA.manhattanValue = CalculateManhattan(stateA.value, goal, step);
                                stateB.manhattanValue = CalculateManhattan(stateB.value, goal, step);

                                int[] sirala = {stateA.manhattanValue,
                                               stateB.manhattanValue};
                                BubbleSort(sirala);
                                State[] states = new State[] { stateA, stateB };

                                foreach (var k in states)
                                {
                                    if (k.manhattanValue == sirala[0] && given != k.value && isok == false)
                                    {
                                        given = k.value.Clone() as int[,];
                                        step++;
                                        for (int a = 0; a <= given.Rank; a++)
                                        {
                                            for (int b = 0; b <= given.Rank; b++)
                                            {
                                                akin = akin + " " + given[a, b].ToString();
                                            }
                                            akin = akin + "\n";
                                        }
                                        akin = akin + "\n";
                                        isok = true;
                                    }
                                }
                                if (ContentEquals(given, goal))
                                {
                                    Console.WriteLine(akin + "Finished in " + step.ToString() + " steps");
                                    return;
                                }
                                isok = false;
                            }
                            //3 state

                            else if ((saydir == 0 && saydir2 == 1))
                            {
                                State stateA = new State();
                                State stateB = new State();
                                State stateC = new State();


                                stateA.value = given.Clone() as int[,];
                                stateB.value = given.Clone() as int[,];
                                stateC.value = given.Clone() as int[,];


                                stateA.value[0, 1] = given[0, 0];
                                stateA.value[0, 0] = given[0, 1];
                                stateB.value[0, 1] = given[1, 1];
                                stateB.value[1, 1] = given[0, 1];
                                stateC.value[0, 1] = given[0, 2];
                                stateC.value[0, 2] = given[0, 1];

                                stateA.manhattanValue = CalculateManhattan(stateA.value, goal, step);
                                stateB.manhattanValue = CalculateManhattan(stateB.value, goal, step);
                                stateC.manhattanValue = CalculateManhattan(stateC.value, goal, step);

                                int[] sirala = {stateA.manhattanValue,
                                               stateB.manhattanValue,stateC.manhattanValue};
                                BubbleSort(sirala);
                                State[] states = new State[] { stateA, stateB, stateC };

                                foreach (var k in states)
                                {
                                    if (k.manhattanValue == sirala[0] && given != k.value && isok == false)
                                    {
                                        given = k.value.Clone() as int[,];
                                        step++;
                                        for (int a = 0; a <= given.Rank; a++)
                                        {
                                            for (int b = 0; b <= given.Rank; b++)
                                            {
                                                akin = akin + " " + given[a, b].ToString();
                                            }
                                            akin = akin + "\n";
                                        }
                                        akin = akin + "\n";
                                        isok = true;
                                    }
                                }
                                if (ContentEquals(given, goal))
                                {
                                    Console.WriteLine(akin + "Finished in " + step.ToString() + " steps");
                                    return;
                                }
                                isok = false;
                            }

                            else if ((saydir == 1 && saydir2 == 0))
                            {
                                State stateA = new State();
                                State stateB = new State();
                                State stateC = new State();

                                stateA.value = given.Clone() as int[,];
                                stateB.value = given.Clone() as int[,];
                                stateC.value = given.Clone() as int[,];

                                stateA.value[1, 0] = given[0, 0];
                                stateB.value[1, 0] = given[1, 1];
                                stateA.value[0, 0] = given[1, 0];
                                stateB.value[1, 1] = given[1, 0];
                                stateC.value[1, 0] = given[2, 0];
                                stateC.value[2, 0] = given[1, 0];

                                stateA.manhattanValue = CalculateManhattan(stateA.value, goal, step);
                                stateB.manhattanValue = CalculateManhattan(stateB.value, goal, step);
                                stateC.manhattanValue = CalculateManhattan(stateC.value, goal, step);

                                int[] sirala = {stateA.manhattanValue,
                                               stateB.manhattanValue,stateC.manhattanValue};
                                BubbleSort(sirala);
                                State[] states = new State[] { stateA, stateB, stateC };

                                foreach (var k in states)
                                {
                                    if (k.manhattanValue == sirala[0] && given != k.value)
                                    {
                                        given = k.value.Clone() as int[,];
                                        step++;
                                        for (int a = 0; a <= given.Rank; a++)
                                        {
                                            for (int b = 0; b <= given.Rank; b++)
                                            {
                                                akin = akin + " " + given[a, b].ToString();
                                            }
                                            akin = akin + "\n";
                                        }
                                        akin = akin + "\n";
                                        isok = true;
                                    }

                                }
                                if (ContentEquals(given, goal))
                                {
                                    Console.WriteLine(akin + "Finished in " + step.ToString() + " steps");
                                    return;
                                }
                                isok = false;
                            }

                            else if ((saydir == 2 && saydir2 == 1))
                            {
                                State stateA = new State();
                                State stateB = new State();
                                State stateC = new State();


                                stateA.value = given.Clone() as int[,];
                                stateB.value = given.Clone() as int[,];
                                stateC.value = given.Clone() as int[,];

                                stateA.value[2, 1] = given[1, 1];
                                stateA.value[1, 1] = given[2, 1];
                                stateB.value[2, 1] = given[2, 0];
                                stateB.value[2, 0] = given[2, 1];
                                stateC.value[2, 1] = given[2, 2];
                                stateC.value[2, 2] = given[2, 1];

                                stateA.manhattanValue = CalculateManhattan(stateA.value, goal, step);
                                stateB.manhattanValue = CalculateManhattan(stateB.value, goal, step);
                                stateC.manhattanValue = CalculateManhattan(stateC.value, goal, step);

                                int[] sirala = {stateA.manhattanValue,
                                               stateB.manhattanValue,stateC.manhattanValue};
                                BubbleSort(sirala);
                                State[] states = new State[] { stateA, stateB, stateC };



                                foreach (var k in states)
                                {
                                    if (k.manhattanValue == sirala[0] && given != k.value && isok == false)
                                    {
                                        given = k.value.Clone() as int[,];
                                        step++;
                                        for (int a = 0; a <= given.Rank; a++)
                                        {
                                            for (int b = 0; b <= given.Rank; b++)
                                            {
                                                akin = akin + " " + given[a, b].ToString();
                                            }
                                            akin = akin + "\n";
                                        }
                                        akin = akin + "\n";
                                        isok = true; 
                                    }
                                    
                                }
                                if (ContentEquals(given, goal))
                                {
                                    Console.WriteLine(akin + "Finished in " + step.ToString() + " steps");
                                    return;
                                }
                                isok = false;
                            }

                            else if ((saydir == 1 && saydir2 == 2))
                            {
                                State stateA = new State();
                                State stateB = new State();
                                State stateC = new State();

                                stateA.value = given.Clone() as int[,];
                                stateB.value = given.Clone() as int[,];
                                stateC.value = given.Clone() as int[,];

                                stateA.value[1, 2] = given[0, 2];
                                stateB.value[1, 2] = given[1, 1];
                                stateA.value[0, 2] = given[1, 2];
                                stateB.value[1, 1] = given[1, 2];
                                stateC.value[1, 2] = given[2, 2];
                                stateC.value[2, 2] = given[1, 2];

                                stateA.manhattanValue = CalculateManhattan(stateA.value, goal, step);
                                stateB.manhattanValue = CalculateManhattan(stateB.value, goal, step);
                                stateC.manhattanValue = CalculateManhattan(stateC.value, goal, step);

                                int[] sirala = {stateA.manhattanValue,
                                               stateB.manhattanValue,stateC.manhattanValue};
                                BubbleSort(sirala);
                                State[] states = new State[] { stateA, stateB, stateC };

                                foreach (var k in states)
                                {
                                    if (k.manhattanValue == sirala[0] && given != k.value && isok == false)
                                    {
                                        given = k.value.Clone() as int[,];
                                        step++;
                                        for (int a = 0; a <= given.Rank; a++)
                                        {
                                            for (int b = 0; b <= given.Rank; b++)
                                            {
                                                akin = akin + " " + given[a, b].ToString();
                                            }
                                            akin = akin + "\n";
                                        }
                                        akin = akin + "\n";
                                        isok = true;
                                    }
                                }
                                if (ContentEquals(given, goal))
                                {
                                    Console.WriteLine(akin + "Finished in " + step.ToString() + " steps");
                                    return;
                                }
                                isok = false;
                            }

                            else if (saydir == 1 && saydir2 == 1)
                            {
                                State stateA = new State();
                                State stateB = new State();
                                State stateC = new State();
                                State stateD = new State();

                                stateA.value = given.Clone() as int[,];
                                stateB.value = given.Clone() as int[,];
                                stateC.value = given.Clone() as int[,];
                                stateD.value = given.Clone() as int[,];


                                stateA.manhattanValue = CalculateManhattan(stateA.value, goal, step);
                                stateB.manhattanValue = CalculateManhattan(stateB.value, goal, step);
                                stateC.manhattanValue = CalculateManhattan(stateC.value, goal, step);
                                stateD.manhattanValue = CalculateManhattan(stateD.value, goal, step);


                                stateA.value[1, 1] = given[1, 2];
                                stateB.value[1, 1] = given[0, 1];
                                stateA.value[1, 2] = given[1, 1];
                                stateB.value[0, 1] = given[1, 1];
                                stateC.value[1, 2] = given[2, 2];
                                stateC.value[2, 2] = given[1, 2];
                                stateD.value[1, 1] = given[2, 1];
                                stateD.value[2, 1] = given[1, 1];


                                int[] sirala = {stateA.manhattanValue,
                                               stateB.manhattanValue,stateC.manhattanValue,stateD.manhattanValue};
                        
                                BubbleSort(sirala);
                                State[] states = new State[] { stateA, stateB, stateC, stateD };

                                foreach (var k in states)
                                {
                                    if (k.manhattanValue == sirala[0] && given != k.value && isok == false)
                                    {
                                        given = k.value.Clone() as int[,];
                                        step++;
                                        for (int a = 0; a <= given.Rank; a++)
                                        {
                                            for (int b = 0; b <= given.Rank; b++)
                                            {
                                                akin = akin + " " + given[a, b].ToString();
                                            }
                                            akin = akin + "\n";
                                        }
                                        akin = akin + "\n";
                                        isok = true;
                                    }
                                }
                                if (ContentEquals(given, goal))
                                {
                                    Console.WriteLine(akin + "Finished in " + step.ToString() + " steps");
                                    return;
                                }   
                                isok = false;
                            }
                        }
                    }
                }
            }

        }

        public static int CalculateManhattan(int[,] given, int[,] goal, int step)
        {
            int toplam = 0;

            for (int i = 0; i <= given.Rank; i++)
            {
                for (int j = 0; j <= goal.Rank; j++)
                {
                    for (int k = 0; k <= given.Rank; k++)
                    {
                        for (int l = 0; l <= goal.Rank; l++)
                        {
                            if (goal[i, j] == given[k, l])
                            {
                                int say = Math.Abs(i - k + j - l);
                                toplam = toplam + say;
                            }


                        }
                    }
                }
            }
            return toplam;
        }

        public static bool ContentEquals<T>(this T[,] arr, T[,] other) where T : IComparable
        {
            if (arr.GetLength(0) != other.GetLength(0) ||
                arr.GetLength(1) != other.GetLength(1))
                return false;
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    if (arr[i, j].CompareTo(other[i, j]) != 0)
                        return false;
            return true;
        }

        public static void BubbleSort(int[] dizi)
        {

            for (int i = 0; i < dizi.Length - 1; i++)
            {
                for (int j = 1; j < dizi.Length - i; j++)
                {
                    if (dizi[j] < dizi[j - 1])
                    {
                        int gecici = dizi[j - 1];
                        dizi[j - 1] = dizi[j];
                        dizi[j] = gecici;
                    }
                }
            }

        }
    }
}
