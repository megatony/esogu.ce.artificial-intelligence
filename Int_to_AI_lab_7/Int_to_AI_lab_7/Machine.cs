using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int_to_AI_lab_7
{
    public class Machine
    {
        public string name { get; set; }
        public Machine previousState { get; set; }
        public List<Job> actualJobs = new List<Job>();
        public int capabilityOfFirstJob { get; set; }
        public int capabilityOfSecondJob { get; set; }
        public int capabilityOfThirdJob { get; set; }
        public int getJobChangingCost()
        {
            int cost = 0;
            try
            {
                for (int i = 0; i < actualJobs.Count; i++)
                {
                    if (actualJobs[i].name == "1st Job")
                    {
                        if (actualJobs[i + 1].name == "2nd Job")
                        {
                            cost += 12;
                        }
                        else if (actualJobs[i + 1].name == "3rd Job")
                        {
                            cost += 10;
                        }
                        else
                        {
                            cost += 0;
                        }
                    }
                    else if (actualJobs[i].name == "2nd Job")
                    {
                        if (actualJobs[i + 1].name == "1st Job")
                        {
                            cost += 4;
                        }
                        else if (actualJobs[i + 1].name == "3rd Job")
                        {
                            cost += 8;
                        }
                        else
                        {
                            cost += 0;
                        }
                    }
                    else if (actualJobs[i].name == "3rd Job")
                    {
                        if (actualJobs[i + 1].name == "1st Job")
                        {
                            cost += 6;
                        }
                        else if (actualJobs[i + 1].name == "2nd Job")
                        {
                            cost += 10;
                        }
                        else
                        {
                            cost += 0;
                        }
                    }
                    else
                    {
                        cost += 0;
                    }
                }
                return cost;
            }
            catch
            {
                return cost;
            }
                
        }
        

        public int GetTotalCapability()
        {
            int capability = 0;
            foreach (var k in actualJobs)
            {
                if (k.name == "1st Job")
                {
                    capability += this.capabilityOfFirstJob + this.getJobChangingCost();
                }
                else if (k.name == "2nd Job")
                {
                    capability += this.capabilityOfSecondJob + this.getJobChangingCost();
                }
                else if (k.name == "3rd Job")
                {
                    capability += this.capabilityOfThirdJob + this.getJobChangingCost();
                }
                else
                {
                    
                }
            }
            return capability;
        }
    }
}
