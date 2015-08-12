using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitor.Utilities
{
    class Options
    {
        //window properties
        public readonly static string HORIZONTAL_WINDOW_HEIGHT = "70";
        public readonly static string HORIZONTAL_WINDOW_WIDTH = "510";
        public readonly static string VERTICAL_WINDOW_HEIGHT = "127";
        public readonly static string VERTICAL_WINDOW_WIDTH = "225";

        //options button properties
        public readonly static string HORIZONTAL_BUTTON_MARGIN = "437,3,0,0";
        public readonly static string HORIZONTAL_BUTTON_HORIZONTAL_ALIGNMENT = "Left";
        public readonly static string BUTTION_VERTICAL_ALIGNMENT = "Top";
        public readonly static string VERTICAL_BUTTION_HORIZONTAL_ALIGNMENT = "";
        public readonly static string VERTICAL_BUTTON_MARGIN = "71,93,71,0";

        //cpu label properties
        public readonly static string CPU_VERTICAL_ALIGNMENT = "Top";
        public readonly static string CPU_HORIZONTAL_ALIGNMENT = "Left";
        public readonly static string HORIZONTAL_CPU_CONTENT_STRING = "CPU Utilization: {0}%";
        public readonly static string VERTICAL_CPU_CONTENT_STRING = "CPU Utilization:               {0}%";

        //RAM label properties
        public readonly static string HORIZONTAL_RAM_MARGIN = "133,0,0,0";
        public readonly static string VERTICAL_RAM_MARGIN = "0,31,0,0";
        public readonly static string RAM_VERTICAL_ALIGNMENT = "Top";
        public readonly static string RAM_HORIZONTAL_ALIGNMENT = "Left";
        public readonly static string HORIZONTAL_RAM_CONTENT_STRING = "RAM Usage: {0}";
        public readonly static string VERTICAL_RAM_CONTENT_STRING = "RAM Usage:       {0}";

        //GPU label properties
        public readonly static string HORIZONTAL_GPU_MARGIN = "331,0,0,0";
        public readonly static string VERTICAL_GPU_MARGIN = "0,62,0,0";
        public readonly static string GPU_VERTICAL_ALIGNMENT = "Top";
        public readonly static string GPU_HORIZONTAL_ALIGNMENT = "Left";
        public readonly static string HORIZONTAL_GPU_CONTENT_STRING = "GPU Temp: {0}°C";
        public readonly static string VERTICAL_GPU_CONTENT_STRING = "GPU Temp:                      {0}°C";
    }
}
