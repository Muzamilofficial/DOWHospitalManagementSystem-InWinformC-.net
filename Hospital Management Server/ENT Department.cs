using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hospital_Management_Server__DOW_Hospital_
{
    public partial class ENT_Department : Form
    {
        public ENT_Department()
        {
            InitializeComponent();
        }

        private void ENT_Department_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Home h2 = new Home();
            h2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DoctorBoking db = new DoctorBoking();
            db.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Dr_Zafar dz = new Dr_Zafar();
            dz.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            DrAbdulFaheemENT daf1 = new DrAbdulFaheemENT();
            daf1.Show();
            this.Hide();
        }
    }
}
