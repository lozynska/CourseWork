using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_New_Test form_New_Test = new Form_New_Test(); 
            form_New_Test.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_Edit form_Edit = new Form_Edit();
            form_Edit.Show();
        }
    }
}
