using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int_to_AI_lab_7
{
    public class Solution
    {
        public static bool flag1 = false;
        public static bool flag2 = false;
        public List<Machine> machineList = new List<Machine>();
        public int getCost()
        {
            int cost = 0;
            foreach (var k in machineList)
            {
                cost = cost + k.GetTotalCapability();
            }
            return cost;
        }
        public Solution getNewSolution()
        {
            Solution newSolution1 = new Solution();

            Machine newMachine1 = new Machine();
            Machine newMachine2 = new Machine();

            newMachine1 = this.machineList[0];
            newMachine2 = this.machineList[1];

            Job job0 = new Job();
            job0.name = "Seperator";
            Job job1 = new Job();
            job1.name = "1st Job";
            Job job2 = new Job();
            job2.name = "2nd Job";
            Job job3 = new Job();
            job3.name = "3rd Job";
            List<Job> karistir = new List<Job>();
            karistir.AddRange(this.machineList[0].actualJobs);
            karistir.Add(job0);
            karistir.AddRange(this.machineList[1].actualJobs);
            newMachine1.actualJobs.Clear();
            newMachine2.actualJobs.Clear();
            Job tempJob = new Job();
            tempJob = karistir[0];
            karistir[0] = karistir[3];
            karistir[3] = tempJob;

            foreach (var k in karistir)
            {
                if (k.name != "Seperator" && flag1 == false)
                {
                    newMachine1.actualJobs.Add(k);
                }
                else
                {
                    flag1 = true;
                }
            }
            flag1 = false;
            foreach (var m in karistir)
            {
                if (m.name == "Seperator" || flag2 == true)
                {
                    flag2 = true;
                    newMachine2.actualJobs.Add(m);
                }
            }
            flag2 = false;
            newMachine1.actualJobs.Remove(job0);
            newMachine2.actualJobs.Remove(job0);
            newSolution1.machineList.Add(newMachine1);
            newSolution1.machineList.Add(newMachine2);
            return newSolution1;     
        }


    }
}
