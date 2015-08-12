using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.VisualBasic.Devices;

namespace ComputerInfoWrapper.RAM
{
    class RAMSensor
    {
        ComputerInfo ci = new Microsoft.VisualBasic.Devices.ComputerInfo();
        private static double totalPhysicalMemory;

        public RAMSensor()
        {
            try
            {
                totalPhysicalMemory = (double) ci.TotalPhysicalMemory;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        public double getTotalRam()
        {
            return totalPhysicalMemory;
        }

        public double getTotalRamInGB()
        {
            return convertToGB(totalPhysicalMemory);
        }

        public double getAvailableRAM()
        {
            try
            {
                return (double) ci.AvailablePhysicalMemory;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            return 0;
        }

        public double getAvailableRAMInGB()
        {
            return convertToGB(getAvailableRAM());
        }

        public double getUsedRAM()
        {
            return totalPhysicalMemory - getAvailableRAM();
        }

        public double getUsedRAMInGB()
        {
                return convertToGB(totalPhysicalMemory - getAvailableRAM());
        }

        public double getPercentRAMUsed()
        {
            return Math.Round(getUsedRAM() / totalPhysicalMemory * 100);
        }

        private double convertToGB(ulong bytes)
        {
            return Math.Round(((double) bytes) / 1024 / 1024 / 1024, 1);
        }

        private double convertToGB(double bytes)
        {
            return Math.Round(bytes / 1024 / 1024 / 1024, 1);
        }
    }
}
