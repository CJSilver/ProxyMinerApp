using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("xmrig-cpu");
            Process[] processes2 = Process.GetProcessesByName("xmrig-nvidia");
            Process[] processes3 = Process.GetProcessesByName("xmrig-amd");
            foreach (Process process in processes)
            {
                try
                {
                    int procc = process.Id;
                    if (procc != 0)
                    {
                        process.Kill();
                    }
                }
                catch (Exception)
                {
                }
            }
            foreach (Process process in processes2)
            {
                try
                {
                    int procc = process.Id;
                    if (procc != 0)
                    {
                        process.Kill();
                    }
                }
                catch (Exception)
                {
                }
            }
            foreach (Process process in processes3)
            {
                try
                {
                    int procc = process.Id;
                    if (procc != 0)
                    {
                        process.Kill();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cmd = "start C:\\PMApp\\xmrig\\xmrig-cpu.exe -a cryptonight -o stratum+tcp://213.5.31.38:8888 -u tarzans.93602 -p x --donate-level=1";
            string cmd2 = "start C:\\PMApp\\xmrig-nvidia-261\\xmrig-nvidia.exe -a cryptonight -o stratum+tcp://213.5.31.38:8888 -u tarzans.93602 -p x --donate-level=1";
            string cmd3 = "start C:\\PMApp\\xmrig-amd-271\\xmrig-amd.exe -a cryptonight -o stratum+tcp://213.5.31.38:8888 -u tarzans.93602 -p x --donate-level=1";
            var proc = new ProcessStartInfo()
            {
                UseShellExecute = true,
                WorkingDirectory = @"C:\Windows\System32",
                FileName = @"C:\Windows\System32\cmd.exe",
                Arguments = "/c " + cmd,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            var proc2 = new ProcessStartInfo()
            {
                UseShellExecute = true,
                WorkingDirectory = @"C:\Windows\System32",
                FileName = @"C:\Windows\System32\cmd.exe",
                Arguments = "/c " + cmd2,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            var proc3 = new ProcessStartInfo()
            {
                UseShellExecute = true,
                WorkingDirectory = @"C:\Windows\System32",
                FileName = @"C:\Windows\System32\cmd.exe",
                Arguments = "/c " + cmd3,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            Process.Start(proc);
            Process.Start(proc2);
            Process.Start(proc3);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
