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

namespace SessionManagement.Daffy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var t1 = new Thread(() => Sleep(5000));
            t1.Name = "Hello Thread";
            t1.Priority = ThreadPriority.BelowNormal;

            t1.Start();
        }

        public void Sleep(int seconds)
        {
            Thread.Sleep(seconds);
        }
    }
}
