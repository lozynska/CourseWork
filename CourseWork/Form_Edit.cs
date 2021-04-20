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

                var file = openFileDialog1.FileName;
                SerialDeserial serialDeserial = new SerialDeserial();
                test = serialDeserial.Deserialize<Test>(file);
                textBox1.Text = test.Author;
                textBox2.Text = test.TestName;
                textBox3.Text = test.Qty_questions;
                foreach (var item in test.Question)
                {
                    listBox1.Items.Add(item);
                    numericUpDown1.Text = item.Difficulty;
                }
                listBox1.SelectedIndex = 0;

            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var qw = (Question)listBox1.SelectedItem;
            foreach (var item in qw.Answer)
            {
                comboBox1.Items.Add(item);
            }
            textBox5.Text = qw.Description;
            //domainUpDown1.Text = qw.Difficulty;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var an = (Answer)comboBox1.SelectedItem;
            textBox6.Text = an.Description;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            var an = (Answer)comboBox1.SelectedItem;
            an.Description = textBox6.Text;
            comboBox1.SelectedItem = an;
            comboBox1.Text = textBox6.Text;
            comboBox1.Invalidate();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            var qw = (Question)listBox1.SelectedItem;
            qw.Description = textBox5.Text;
            listBox1.SelectedItem = qw;
            listBox1.Text = textBox5.Text;
            textBox5.Invalidate();
        }
    }
}
