using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace storedProceduresApp
{
    public partial class Form1 : Form
    {
        DataHandler handler = new DataHandler();//always initialise data handler
        BindingSource bs = new BindingSource();//always initialise binding source
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            dgvStudents.DataSource = bs;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            handler.displayStudents();
            bs.DataSource = handler.students;
        }

        private void btnAddStud_Click(object sender, EventArgs e)
        {
            handler.insertData(int.Parse(txtStudId.Text), txtName.Text, txtSurname.Text, txtCourse.Text);
        }
    }
}
