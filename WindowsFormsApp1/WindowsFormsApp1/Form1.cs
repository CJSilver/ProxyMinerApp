using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly ErrorProvider _errorProvider1;
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            _errorProvider1 = new ErrorProvider(this);
            textBox4.Validating += TextBoxIntOnValidating;
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("xmrig-cpu");
            Process[] processes2 = Process.GetProcessesByName("xmrig-nvidia");
            Process[] processes3 = Process.GetProcessesByName("xmrig-amd");
            Process[] processes4 = Process.GetProcessesByName("startup");
            Process[] processes5 = Process.GetProcessesByName("Node");

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
            foreach (Process process in processes4)
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
            foreach (Process process in processes5)
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
            Static.pool = textBox1.Text;
            Static.user = textBox2.Text;
            Static.pass = textBox3.Text;
            using (StreamWriter pools = new StreamWriter("C:\\PMApp\\xmrig\\pools.json", false))
            {
                pools.Write("[{\"pool_address\":\"stratum+tcp://" + Static.pool + "\",\"wallet_address\": \"" + Static.user + "\",\"pool_password\":\"" + Static.pass + "\",\"keepalive\": null,\"emu_nicehash\": false,\"max_workers\": 1,\"retry_count_connect\": 5}]");
            }
            if (checkBox2.Checked)
            {
                Static.px = 1;
            }
            else
            {
                Static.px = 0;
            }
            if (checkBox3.Checked)
            {
                Static.py = 3;
            }
            else
            {
                Static.py = 0;
            }
            if (checkBox4.Checked)
            {
                Static.pz = 5;
            }
            else
            {
                Static.pz = 0;
            }

            int toMs = 1000;
            int stdSec = 10;
            if(textBox4.Text == "Refresh time in seconds")
            {
                Static.refresh = stdSec * toMs;
            }
            else
            {
                if(Int32.Parse(textBox4.Text) > 0)
                {
                    Static.refresh = Int32.Parse(textBox4.Text) * toMs;
                }
                else
                {
                    Static.refresh = stdSec * toMs;
                }
            }
            Form2 f2 = new Form2();
            f2.Show();
        }

            private void Form1_Load(object sender, EventArgs e)
            {

            }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Static.bg = " -B";
        }
        private void TextBoxIntOnValidating(object sender, CancelEventArgs cancelEventArgs)
        {
            try
            {
                int x = Int32.Parse(textBox4.Text);

                _errorProvider1.SetError(textBox4, "");
            }
            catch (Exception e)
            {
                _errorProvider1.SetError(textBox4, "Only number.");
                textBox4.Text = "Refresh time in seconds";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Static.cpu = true;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Static.cuda = true;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            Static.ocl = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }
    }
    }
