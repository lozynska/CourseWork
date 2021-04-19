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
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                var file = openFileDialog1.FileName;
                SerialDeserial serialDeserial = new SerialDeserial();
                test = serialDeserial.Deserialize<Test>(file);
                textBox1.Text = test.Author;


            }
        }
    }
}
