using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ComputerInfoWrapper.CPU
{
    class CPUSensor
    {
        private PerformanceCounter counter = new PerformanceCounter(); 

        public CPUSensor()
        {
            counter.CategoryName = "Processor Information";
            counter.CounterName = "% Processor Time";
            counter.InstanceName = "_Total";
        }

        public CPUSensor(String cpuNum)
        {
            counter.CategoryName = "Processor";
            counter.CounterName = "% Processor Time";
            counter.InstanceName = cpuNum;
        }

        public float getCPUUsage()
        {
            float temp = -1;

            try
            {
                temp = counter.NextValue();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            return temp;
        }


    }
}
