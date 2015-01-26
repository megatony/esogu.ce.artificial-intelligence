using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int_to_AI_lab_7
{
    class Program
    {
        public static bool flag = false;
        public static string akin;
        static void Main(string[] args)
        {
            Job job1 = new Job();
            job1.name = "1st Job";
            Job job2 = new Job();
            job2.name = "2nd Job";
            Job job3 = new Job();
            job3.name = "3rd Job";

            Machine machine1 = new Machine();
            machine1.name = "1st Machine";
            machine1.capabilityOfFirstJob = 10;
            machine1.capabilityOfSecondJob = 4;
            machine1.capabilityOfThirdJob = 8;
            machine1.actualJobs.Add(job1);
            Machine machine2 = new Machine();
            machine2.name = "2nd Machine";
            machine2.capabilityOfFirstJob = 12;
            machine2.capabilityOfSecondJob = 9;
            machine2.capabilityOfThirdJob = 5;
            machine2.actualJobs.Add(job2);
            machine2.actualJobs.Add(job3);
            Solution bestSolution = null;
            Solution firstSolution = new Solution();
            Queue<Solution> tabuList = new Queue<Solution>();
            HashSet<Solution> solutionList = new HashSet<Solution>();
            firstSolution.machineList.Add(machine1);
            firstSolution.machineList.Add(machine2);
            bestSolution = firstSolution;
            int iterationCount = 5;
            bool controller = false;
            while (controller == false && iterationCount>1)
            {
                if (bestSolution.getNewSolution().getCost() < bestSolution.getCost())
                {
                    bestSolution = bestSolution.getNewSolution();
                }
                else if (iterationCount == 5)
                {
                    tabuList.Enqueue(bestSolution.getNewSolution());
                }
                else if (tabuList.Count == 3)
                {
                    tabuList.Dequeue();
                }
                Solution _bestSolution = bestSolution.getNewSolution().getNewSolution();

                foreach (var k in tabuList)
                {
                   flag = false;
                    if (k == _bestSolution)
                    {
                        flag = true;
                        return;
                    }
                    else
                    {
                        flag = false;
                    }
                }
                if (flag != true)
                {
                    bestSolution = _bestSolution;
                    iterationCount--;
                }
                else
                {
                    controller = true;
                }
            }
            for (int i = 0; i < bestSolution.machineList[0].actualJobs.Count; i++)
            {
                akin = akin + bestSolution.machineList[0].name + "\n" +
                    bestSolution.machineList[0].actualJobs[i].name + "\n";
            }
            for (int i = 0; i < bestSolution.machineList[1].actualJobs.Count; i++)
            {
                akin = akin + "\n" + bestSolution.machineList[1].name + "\n" +
                    bestSolution.machineList[1].actualJobs[i].name + "\n";
            }


            Console.WriteLine(akin + "\n Cost: " + bestSolution.getCost().ToString());
            //çözüm=başlangıç çözümü,
            //en_iyi_çözüm=çözüm, 
            //tabu_listesi (boş),
            //durdurma_kriteri,
            //kontrol=false,
            //repeat
            //–  eğer çözüm>en_iyi_çözüm ise en_iyi_çözüm=çözüm
            //–  eğer durdurma_kriteri’ ne ulaşılmış ise çözümü tabu_listesine ekle 
            //•  eğer tabu_listesi dolu ise ilk gireni listeden çıkar,
            //çözümlerin içinden başka birini yeni_çözüm olarak seç
            //•  eğer yeni_çözüm bulunamadıysa veya 
            //(eğer geliştirilen yeni_çözüm, uzun_dönem_hafıza da bulunuyor ise yeni_çözümü rasgele üret)
            //•  eğer yeni_çözüm, tabu_listesi’ nde yok ise çözüm=yeni_çözüm
            //değil ise kontrol=true
            //until kontrol=true

        }

    }
}
