using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestLib;

namespace CourseWork
{
    public partial class Form_Edit : Form
    {
        Test test;
        string file;
        BindingSource qtBs;
        BindingSource anBs;
        public Form_Edit()
        {
            InitializeComponent();
            listBox1.DisplayMember = "Description";
            comboBox1.DisplayMember = "Description";
            
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                file = openFileDialog1.FileName;
                SerialDeserial serialDeserial = new SerialDeserial();
                test = serialDeserial.Deserialize<Test>(file);
                textBox1.DataBindings.Clear();
                textBox1.DataBindings.Add("Text", test, "Author");
                textBox2.DataBindings.Clear();
                textBox2.DataBindings.Add("Text", test, "Title");
                textBox3.DataBindings.Clear();
                textBox3.DataBindings.Add("Text", test, "Qty_questions");
                
                qtBs = new BindingSource(test, "Questions");
                listBox1.DataSource = qtBs;
               
               
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                var qw = (Question)listBox1.SelectedItem;
                anBs = new BindingSource(qw, "Answer");
                comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;
                comboBox1.DataSource = anBs;
                var correct = qw.Answer.First(a => a.IsRight == "True");
                comboBox1.SelectedItem = correct;
                comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
                textBox5.DataBindings.Clear();
                textBox5.DataBindings.Add("Text", qw, "Description");
                numericUpDown1.DataBindings.Clear();
                numericUpDown1.DataBindings.Add("Text", qw, "Difficulty");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                var an = (Answer)comboBox1.SelectedItem;
                textBox6.DataBindings.Clear();
                textBox6.DataBindings.Add("Text", an, "Description");
                var qw = (Question)listBox1.SelectedItem;
                qw.Answer.ForEach(a => a.IsRight = a==an? "True":"False");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                var an = (Answer)comboBox1.SelectedItem;
                an.Description = textBox6.Text;
                comboBox1.SelectedItem = an;
                comboBox1.Text = textBox6.Text;
                comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
                comboBox1.DrawMode = DrawMode.Normal;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                var qw = (Question)listBox1.SelectedItem;
                qw.Description = textBox5.Text;
                listBox1.SelectedItem = qw;
                listBox1.DrawMode = DrawMode.OwnerDrawFixed;
                listBox1.DrawMode = DrawMode.Normal;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var qw = (Question)listBox1.SelectedItem;
            qw.Description = textBox5.Text;
            listBox1.SelectedItem = qw;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                var qw = (Question)listBox1.SelectedItem;
                listBox1.SelectedItem = null;
                test.Questions.Remove(qw);
                qtBs.ResetBindings(false);
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                var ans = (Answer)comboBox1.SelectedItem;
                var qw = (Question)listBox1.SelectedItem;
                comboBox1.SelectedItem = null;
                qw.Answer.Remove(ans);
                anBs.ResetBindings(false);                
                textBox6.Text = "";
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {   


            SerialDeserial serialDeserial = new SerialDeserial();
           
            serialDeserial.Serialize(test, file);
            MessageBox.Show("File is saved");
        }
    }
}
