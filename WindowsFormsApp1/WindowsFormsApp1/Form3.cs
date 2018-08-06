using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }



        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Text = "30";
            textBox2.Text = "500";
            textBox3.Text = "500";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamWriter config = new StreamWriter("C:\\PMApp\\xmrig\\config.json", false))
            {
                config.Write("{stratum_servers:[{bind_address: " + "\"" + "0.0.0.0:8888" + "\"" + ",share_time: " + textBox1.Text + ",start_difficulty: " + textBox2.Text + ",min_difficulty: " + textBox3.Text + ",ssl: false,},],web_server:{enable:false,},}");
            }
            MessageBox.Show("Settings saved in config.json");
            Close();
        }
    }
}
