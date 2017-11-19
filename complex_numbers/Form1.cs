using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            draw_axis();
        }

        private void show_complex(float re, float im){
            Graphics gr = this.CreateGraphics();
            float x_centre = (this.Width - 200) / 2, y_centre = this.Height / 2;
            Pen point = new Pen(Color.Black, 4);
            // отобразить точку на плоскости
            gr.FillEllipse(Brushes.Black, x_centre+re*20, y_centre+im*20, 4, 4);
            // рисуем стрелочку рандомный цветом
            Random rnd = new Random();
            Byte[] b = new Byte[3];
            rnd.NextBytes(b);
            Color arrow_color = Color.FromArgb(b[0],b[1],b[2]);
            Pen arrow = new Pen(arrow_color, 4);
            arrow.EndCap = LineCap.ArrowAnchor;
            gr.DrawLine(arrow,x_centre,y_centre,(x_centre + re * 20)+1, y_centre + im * 20);
        }

        private void draw_axis()
        {
            int clientWidth = this.Width - 200;
            int clientHeight = this.Height;
            int k = -19;
            int l = 14;
            float i = 19; // clientWidth / 2 + 20 
            float j = 19;
            // отрисовка осей и их подпись
            Graphics gr = this.CreateGraphics();
            Pen axis = new Pen(Color.Red, 4);
            axis.StartCap = LineCap.ArrowAnchor;
            Font font = new Font("Tahoma", 14);
            Font points_font = new Font("Tahoma", 8);
            SolidBrush brush = new SolidBrush(Color.Black);
            // сами оси
            gr.DrawLine(axis, clientWidth / 2, 0, clientWidth / 2, clientHeight);
            gr.DrawLine(axis, clientWidth, clientHeight / 2, 0, clientHeight / 2);
            
            while (i < clientWidth-1) {
                gr.FillEllipse(Brushes.Black,i,clientHeight/2-2,4,4);
                gr.DrawString(k.ToString(), points_font, Brushes.Black, i, clientHeight/2+10);
                k++;
                i += 20;
            }
            while (j < clientHeight-1)
            {
                gr.FillEllipse(Brushes.Black,clientWidth/2-1,j,4,4);
                if (l!=0)
                    gr.DrawString(l.ToString()+"i",points_font,Brushes.Black,clientWidth/2+5,j);
                l--;
                j += 20;
            }
            // надписи около осей
            gr.DrawString("Im", font, brush, clientWidth / 2 + 20, 10);
            gr.DrawString("Re", font, brush, clientWidth - 30, clientHeight / 2 + 15);
            gr.Dispose();
        }

        private void Form1_Paint(object sender, PaintEventArgs e) {
            //draw_axis();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics gr = this.CreateGraphics();
            gr.Clear(this.BackColor);
            draw_axis();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // немного из stackoverflow, писал на скорую руку, потом запилю класс complex
            String inp1, inp2;
            float re1, re2, im1, im2, re,im;
            inp1 = textBox1.Text;
            inp2 = textBox2.Text;
            inp1 = inp1.Replace(',', '.');
            inp2 = inp2.Replace(',', '.');
            string regexPattern =
            @"([-+]?\d+\.?\d*|[-+]?\d*\.?\d+)" +
            @"\s*" +
            @"[-+]" +
            @"\s*" +
            @"([-+]?\d+\.?\d*|[-+]?\d*\.?\d+)" +
            @"i";
            Regex regex = new Regex(regexPattern);
            if (inp1 != "" && inp2 != "")
            {
                Match match1 = regex.Match(inp1);
                Match match2 = regex.Match(inp2);
                // первое число
                re1 = float.Parse(match1.Groups[1].Value, CultureInfo.InvariantCulture);
                im1 = float.Parse(match1.Groups[2].Value, CultureInfo.InvariantCulture);
                // второе число 
                re2 = float.Parse(match2.Groups[1].Value, CultureInfo.InvariantCulture);
                im2 = float.Parse(match2.Groups[2].Value, CultureInfo.InvariantCulture);

                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        re = re1 + re2;
                        im = im1 + im2;
                        if (im > 0)
                            textBox3.Text = re.ToString() + "+" + im.ToString() + "i";
                        else if (im < 0)
                            textBox3.Text = re.ToString() + im.ToString() + "i";
                        else if (im == 0)
                            textBox3.Text = re.ToString() + "+" + im.ToString() + "i";
                        break;
                    case 1:
                        re = re1 - re2;
                        im = im1 - im2;
                        if (im > 0)
                            textBox3.Text = re.ToString() + "+" + im.ToString() + "i";
                        else if (im < 0)
                            textBox3.Text = re.ToString() + im.ToString() + "i";
                        else if (im == 0)
                            textBox3.Text = re.ToString() + "+" + im.ToString() + "i";
                        break;
                    case 2:
                        re = re1 * re2 - im1 * im2;
                        im = im1 * re2 + re1 * im2;
                        if (im > 0)
                            textBox3.Text = re.ToString() + "+" + im.ToString() + "i";
                        else if (im < 0)
                            textBox3.Text = re.ToString() + im.ToString() + "i";
                        else if (im == 0)
                            textBox3.Text = re.ToString() + "+" + im.ToString() + "i";
                        break;
                    case 3:
                        re = (re1 * re2 + im1 * im2) / (re2 * re2 + im2 * im2);
                        im = (im1 * re2 - re1 * im2) / (re2 * re2 + im2 * im2);
                        if (im > 0)
                            textBox3.Text = re.ToString() + "+" + im.ToString() + "i";
                        else if (im < 0)
                            textBox3.Text = re.ToString() + im.ToString() + "i";
                        else if (im == 0)
                            textBox3.Text = re.ToString() + "+" + im.ToString() + "i";
                        break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String inp = textBox3.Text;
            inp = inp.Replace(',', '.');
            float re, im;
            string regexPattern =
            @"([-+]?\d+\.?\d*|[-+]?\d*\.?\d+)" +
            @"\s*" +
            @"[-+]" +
            @"\s*" +
            @"([-+]?\d+\.?\d*|[-+]?\d*\.?\d+)" +
            @"i";
            Regex regex = new Regex(regexPattern);
            if (inp != ""){
                Match match = regex.Match(inp);
                re = float.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
                im = float.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture);
                show_complex(re, im);
            }
        }
    }
}
