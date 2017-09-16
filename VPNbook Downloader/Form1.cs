using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPNbook_Downloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void DownloadStrings()
        {
            try
            {
                WebClient wc = new WebClient();
                if (checkBox1.Checked == true)
                {
                    string[] splitted = textBox3.Text.ToString().Split(':');
                    wc.Proxy = new WebProxy(splitted[0], Convert.ToInt32(splitted[1]));
                }
                Uri url = new Uri("https://www.vpnbook.com/");
                string html = wc.DownloadString(url);
                Group Username = Regex.Match(html, @"<strong>Username: ([a-z0]+)").Groups[1];
                Group Password = Regex.Match(html, @"<strong>Password: (.+?)<").Groups[1];
                textBox1.Text = Username.ToString();
                textBox2.Text = Password.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
                MessageBox.Show("Something went wrong!\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DownloadStrings();
            textBox1.Enabled = true;
            textBox2.Enabled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox3.Enabled = true;
            }
            else
            {
                textBox3.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by ictground. Please visit www.ictground.com for more!", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
