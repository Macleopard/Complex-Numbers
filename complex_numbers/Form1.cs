using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        private void draw_axis()
        {
            // отрисовка осей и их подпись
            Graphics gr = this.CreateGraphics();
            Pen axis = new Pen(Color.Red, 4);
            axis.StartCap = LineCap.ArrowAnchor;
            Font font = new Font("Tahoma", 16);
            SolidBrush brush = new SolidBrush(Color.Black);
            // сами оси
            gr.DrawLine(axis, (this.Width - 200) / 2, 0, (this.Width - 200) / 2, this.Height);
            gr.DrawLine(axis, this.Width - 200, this.Height / 2, 0, this.Height / 2);
            // надписи около осей
            gr.DrawString("Re", font, brush, (this.Width-200)/2 + 10, 10);
            gr.DrawString("Im", font, brush, (this.Width-200) - 30, this.Height/2 + 10);
            gr.Dispose();
        }

        private void Form1_Paint(object sender, PaintEventArgs e) {
            draw_axis();
        }
    }
}
