using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace complex_numbers
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

        private void Form1_Paint(object sender, PaintEventArgs e) {
            Graphics gr = e.Graphics;
            Pen p = new Pen(Color.Red, 3);
            gr.DrawLine(p, (this.Width-200)/2, 0, (this.Width - 200) / 2, this.Height);
            gr.DrawLine(p, 0, this.Height/2, this.Width-200, this.Height/2);
            gr.Dispose();
        }
    }
}
