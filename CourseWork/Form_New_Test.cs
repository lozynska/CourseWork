using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestLib;

namespace CourseWork
{
    public partial class Form_New_Test : Form
    {
        List<Question> questions = new List<Question>();
        int num ;
        public Form_New_Test()
        {
            InitializeComponent();
            listBox1.DisplayMember = "Description";
            comboBox1.DisplayMember = "Description";
            num = 0;
            textBox3.Text = num.ToString();
            textBox6.Text = @"Tests";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Test test = new Test();
            test.Author = textBox1.Text;
            test.Title = textBox2.Text;
            test.Qty_questions = textBox3.Text;
            test.Questions = questions;
            test.DtCreate = DateTime.Now;
            SerialDeserial serialDeserial = new SerialDeserial();
            var file = textBox6.Text + Path.DirectorySeparatorChar + test.Title + ".xml" ;
            serialDeserial.Serialize(test, file);
            MessageBox.Show("File is saved");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Question question = new Question();
            question.Description = textBox4.Text;
            question.Difficulty = numericUpDown1.Text;
            question.Answer = new List<Answer>();
            foreach (var i in comboBox1.Items)
            {
                Answer a = (Answer)i;
                question.Answer.Add(a);
              
            }
            num++;
            textBox3.Text = num.ToString();
            textBox4.Text = "";
            textBox5.Text = "";
            listBox1.Items.Clear();
            comboBox1.Items.Clear();
            questions.Add(question);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Answer answer = new Answer();
            answer.Description = textBox5.Text;           
            answer.IsRight = checkBox1.Checked.ToString();
            if (answer.IsRight == "True")
            {
                comboBox1.Text = answer.Description;
                foreach (var i in comboBox1.Items)
                {
                    Answer a = (Answer)i;
                    a.IsRight = "False";
                }
            }
            comboBox1.Items.Add(answer);
            listBox1.Items.Add(answer);
            textBox5.Text = "";
            checkBox1.Checked = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var i in comboBox1.Items)
            {
                Answer a = (Answer)i;

                a.IsRight = "False";
                
            }
            Answer ans = (Answer)comboBox1.SelectedItem;
            ans.IsRight= "True";
        }
    }
}
