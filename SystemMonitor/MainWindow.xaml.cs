using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using ComputerInfoWrapper.CPU;
using ComputerInfoWrapper.RAM;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace SystemMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static DispatcherTimer timer = new DispatcherTimer();
        private static CPUSensor cpuSensor = new CPUSensor();
        private static RAMSensor ramSensor = new RAMSensor();

        [DllImport("NvidiaAPIWrapperDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int getGPUTemp();

        [DllImport("NvidiaAPIWrapperDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void freeWrapper();

        public MainWindow()
        {
            InitializeComponent();
            Closing += MainWindow_Closing;
            setUpDispatchTimer();
        }

        private void setUpDispatchTimer()
        {
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += new EventHandler(monitor);
            timer.Start();
        }

        private void monitor(object sender, EventArgs e)
        {
            cpuLabel.Content = ((int) cpuSensor.getCPUUsage()).ToString();
            gpuLabel.Content = getGPUTemp().ToString();
            ramLabel.Content = String.Format("{0} / {1} GB  {2}%", ramSensor.getUsedRAMInGB().ToString(), ramSensor.getTotalRamInGB().ToString(), ramSensor.getPercentRAMUsed().ToString());
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            freeWrapper();
        }
    }
}
