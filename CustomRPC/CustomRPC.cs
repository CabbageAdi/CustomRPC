using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomRPC
{
    public partial class CustomRPC : Form
    {
        public CustomRPC()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.UpdateRPC(textBox1.Text, numericUpDown1.Value, numericUpDown2.Value, numericUpDown3.Value, numericUpDown4.Value);
        }
    }
}
