using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Практическая_работа_16
{
    public partial class Form1 : Form
    {
        int veter, vector, schetchik;        
        Rectangle r1, r2;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left)//если нажата стрелка влево
                vector = -15;//вектор смещения влево
            if (e.KeyData == Keys.Right)//если нажата стрелка вправо
                vector = 15;//вектор смещения вправо
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int skorost_padenia = 7;//скорость падения
            //перемещение по X 
            pictureBox3.Left = pictureBox3.Left + veter + vector;
            //Перемещение по Y
            pictureBox3.Top = pictureBox3.Top + skorost_padenia;
            schetchik++;//Увеличиваем значение
            if (schetchik > 10)
                schetchik = 0;
            //Если семка скрылся за форму
            if (pictureBox3.Top >= pictureBox1.Height)
            {
                timer1.Enabled = false;
                MessageBox.Show("Вы проиграли");
            }
            r1 = pictureBox3.DisplayRectangle; r2 = pictureBox2.DisplayRectangle;
            r1.Location = pictureBox3.Location; r2.Location = pictureBox2.Location;
            //если попал на белку
            if (r1.IntersectsWith(r2)==true)
            {
                timer1.Enabled = false;
                MessageBox.Show("Вы покормли белку!");
            }
        }

        private void стартToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random r = new Random();//рандом
            pictureBox3.Left = r.Next(80, 400);
            pictureBox3.Top = -80;
            timer1.Enabled = true;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            vector = 0;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {          
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            pictureBox3.Height = 50;//высота ореха
            pictureBox3.Width = 70;//ширина ореха   
            pictureBox2.Parent = pictureBox1;
            pictureBox3.Parent = pictureBox1;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            Random r = new Random();//рандом          
            pictureBox3.Left = r.Next(80, 400);
            pictureBox3.Top = -80;
            veter = r.Next(5);//Сила ветра
            vector = 0;
            schetchik = 1;//счетчик для отображения картинок
        }
    }
}
