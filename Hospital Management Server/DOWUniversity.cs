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
    public partial class DOWUniversity : Form
    {
        public DOWUniversity()
        {
            InitializeComponent();
        }

        private void DOWUniversity_Load(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {
            Home h1 = new Home();
            h1.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home h2 = new Home();
            h2.Show();
            this.Hide();
        }

        private void dOWUniversityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DOWUniversity DU = new DOWUniversity();
            DU.Show();
            this.Hide();
        }
    }
}
