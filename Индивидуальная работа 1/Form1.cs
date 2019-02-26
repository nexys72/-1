using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//библиотека для работы с файлами
using System.IO;


namespace Индивидуальная_работа_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("111.txt");
            //строка файла
            String line = sr.ReadLine();
            int n = 0;
            numericUpDown1.Maximum = 0;
            //перезапись коллекции listBox из текстового файла
            listBox1.Items.Clear();
            while(line!=null)
            {
                string[] s = line.Split(';');
                listBox1.Items.Add(line);
                line = sr.ReadLine();
                n++;
                numericUpDown1.Maximum++;
            }
            //определение количества строк в файле
            numericUpDown1.Maximum = --n;
            sr.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            //кнопка сохранения становится видимой для записи строки в файл
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //проверка на пустые значения
            if ((textBox1.Text == "") & (textBox2.Text == "") & (textBox3.Text == "") & (textBox4.Text == "") & (textBox5.Text == "") & (textBox6.Text == "") & (textBox7.Text == ""))
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                //запись строки в файл
                File.AppendAllText("111.txt", "\n"+textBox1.Text + "; " + textBox2.Text + "; " + textBox3.Text + "; " + textBox4.Text + "; " + textBox5.Text + "; " + textBox6.Text + "; "+ textBox7.Text);
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                textBox7.Enabled = false;
                button2.Visible = false;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
            }
            //обновление данных для просмотра
            Form1_Load(sender,e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("111.txt");
            string line = sr.ReadLine();
            //string[] line = File.ReadAllLines("111.txt");
            int n = 0;
            //string[] s;
            //вывод строки с данными в textbox для редактирования
            while (line != null)
            {
                //s = line[n].Split(';');
                string[] s = line.Split(';');
                if (n == numericUpDown1.Value)
                {
                    textBox1.Text = s[0]; //название предприятия
                    textBox2.Text = s[1]; //форма организации
                    textBox3.Text = s[2]; //тел приемной
                    textBox4.Text = s[3]; //фио директора
                    textBox5.Text = s[4]; //тел директора
                    textBox6.Text = s[5]; //факс
                    textBox7.Text = s[6]; //юр адрес
                }
                line = sr.ReadLine();
                n++;
            }
            
            sr.Close();
            
            label7.Text = Convert.ToString((int)numericUpDown1.Value);
            button4.Visible = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            button3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String[] line = File.ReadAllLines("111.txt");
            int n = Convert.ToInt16(label7.Text);
            line[n] = textBox1.Text + "; " + textBox2.Text + "; " + textBox3.Text + "; " + textBox4.Text + "; " + textBox5.Text + "; " + textBox6.Text + ";" + textBox7.Text;
            File.Delete("111.txt");
            File.AppendAllLines("111.txt", line);
            Form1_Load(sender, e);
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            button2.Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            label7.Text = "";
            button4.Visible = false;
            button3.Enabled = true;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
