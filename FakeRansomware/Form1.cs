using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FakeRansomware
{
    public partial class Form1 : Form
    {
        bool stopCountdown = false;

        public Form1()
        {
            InitializeComponent();
        }
        async Task<int> startCountdown(DateTime expire)
        {
            while (!stopCountdown)
            {
                TimeSpan ts = (expire - DateTime.Now);
                this.Invoke((MethodInvoker)delegate
                {
                    lblCounter.Text = ts.ToString(@"hh\:mm\:ss");
                });
                Thread.Sleep(1000);
            }
            return 0;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (stopCountdown == false)
            {
                e.Cancel = true;
                base.OnClosing(e);
            }
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            DateTime appStarted = DateTime.Now;
            await Task.Run(() => startCountdown(appStarted.AddDays(1)));
            this.Close();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "1234")
            {
                textBox1.BackColor = Color.Green;
                stopCountdown = true;
            }
        }
    }

}
