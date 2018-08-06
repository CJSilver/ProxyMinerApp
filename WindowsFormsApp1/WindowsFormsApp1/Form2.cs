using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using J = Newtonsoft.Json.JsonPropertyAttribute;
using R = Newtonsoft.Json.Required;
using N = Newtonsoft.Json.NullValueHandling;

namespace WindowsFormsApp1
{

    public partial class Form2 : Form
    {
        

        public Form2()
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
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

        int prt = 0;

        private void Form2_Load(object sender, EventArgs e)
        {
            string cmd = "start C:\\PMApp\\xmrig\\xmrig-cpu.exe" + Static.bg + " -a cryptonight -o stratum+tcp://" + Static.pool + " -u " + Static.user + " -p " + Static.pass + " --api-port 9001";
            string cmd2 = "start C:\\PMApp\\xmrig\\xmrig-nvidia.exe" + Static.bg + " -a cryptonight -o stratum+tcp://" + Static.pool + " -u " + Static.user + " -p " + Static.pass + " --api-port 9002";
            string cmd3 = "start C:\\PMApp\\xmrig\\xmrig-amd.exe" + Static.bg + " -a cryptonight -o stratum+tcp://" + Static.pool + " -u " + Static.user + " -p " + Static.pass + " --api-port 9003";
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
            timer2.Interval = Static.refresh;
            label1.Text = "Wait! Starting miner and Data loading";
            timer1.Start();
            timer2.Start();

            if (Static.cpu)
            {
                prt = 1;
            }
            else
            {
                if (Static.cuda)
                {
                    prt = 2;
                }
                else
                {
                    if (Static.ocl)
                    {
                        prt = 3;
                    }
                }
            }
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
          
            var webClient = new WebClient();
            var response = webClient.DownloadString("http://127.0.0.1:900" + prt.ToString());
            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(response);

            this.Text = rootObject.Ua;
            

                
                label1.Text = "CPU\n" + rootObject.Cpu.Brand + "\n\nMining Device\n" + rootObject.Kind + "\n\nDiff\n" + rootObject.Results.DiffCurrent + "\n\nTotal threads\n" + rootObject.Hashrate.Threads.Length + "\n\nTotal 10 sec. hasrate\n" + rootObject.Hashrate.Total[0] + "\n\nTotal 60 sec. hashrate\n" + rootObject.Hashrate.Total[1]  + "\n\nMaximal hashrate\n" + rootObject.Hashrate.Highest + "\n\nAccepted shares\n" + rootObject.Results.SharesGood + "\n\nTotal shares\n" + rootObject.Results.SharesTotal + "\n\nTotal hashes\n" + rootObject.Results.HashesTotal;

            
            
            
        }

        
        private void timer2_Tick(object sender, EventArgs e)
        {
            if(Static.px + Static.py + Static.pz == 1) //cpu
            {
                prt = 1;
            }
            if (Static.px + Static.py + Static.pz == 3) //cuda
            {
                prt = 2;
            }
            if (Static.px + Static.py + Static.pz == 5) //ocl
            {
                prt = 3;
            }
            if (Static.px + Static.py + Static.pz == 4) //cpu cuda
            {
                if (prt < 2)
                {
                    prt++;
                }
                else
                {
                    if(prt >= 2)
                    {
                        prt = 1;

                    }
                }
            }
            if (Static.px + Static.py + Static.pz == 6) //cpu ocl
            {
                if (prt < 3)
                {
                    prt = prt + 2;
                }
                else
                {
                    if (prt >= 3)
                    {
                        prt = 1;

                    }
                }
            }
            if (Static.px + Static.py + Static.pz == 8) //cuda ocl
            {
                if (prt < 3)
                {
                    prt++;
                }
                else
                {
                    if (prt >= 3)
                    {
                        prt = 2;

                    }
                }
            }
            if (Static.px + Static.py + Static.pz == 9) //cpu cuda ocl
            {
                if (prt < 3)
                {
                    prt++;
                }
                else
                {
                    if (prt >= 3)
                    {
                        prt = 1;

                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
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

            this.Close();
        }
    }
    public partial class RootObject
    {
        [J("id")] public string Id { get; set; }
        [J("worker_id")] public string WorkerId { get; set; }
        [J("version")] public string Version { get; set; }
        [J("kind")] public string Kind { get; set; }
        [J("ua")] public string Ua { get; set; }
        [J("cpu")] public Cpu Cpu { get; set; }
        [J("algo")] public string Algo { get; set; }
        [J("hugepages")] public bool Hugepages { get; set; }
        [J("donate_level")] public long DonateLevel { get; set; }
        [J("hashrate")] public Hashrate Hashrate { get; set; }
        [J("results")] public Results Results { get; set; }
        [J("connection")] public Connection Connection { get; set; }
    }

    public partial class Connection
    {
        [J("pool")] public string Pool { get; set; }
        [J("uptime")] public long Uptime { get; set; }
        [J("ping")] public long Ping { get; set; }
        [J("failures")] public long Failures { get; set; }
        [J("error_log")] public object[] ErrorLog { get; set; }
    }

    public partial class Cpu
    {
        [J("brand")] public string Brand { get; set; }
        [J("aes")] public bool Aes { get; set; }
        [J("x64")] public bool X64 { get; set; }
        [J("sockets")] public long Sockets { get; set; }
    }

    public partial class Hashrate
    {
        [J("total")] public decimal[] Total { get; set; }
        [J("highest")] public decimal Highest { get; set; }
        [J("threads")] public decimal[][] Threads { get; set; }
    }

    public partial class Results
    {
        [J("diff_current")] public long DiffCurrent { get; set; }
        [J("shares_good")] public long SharesGood { get; set; }
        [J("shares_total")] public long SharesTotal { get; set; }
        [J("avg_time")] public long AvgTime { get; set; }
        [J("hashes_total")] public long HashesTotal { get; set; }
        [J("best")] public long[] Best { get; set; }
        [J("error_log")] public object[] ErrorLog { get; set; }
    }

}
