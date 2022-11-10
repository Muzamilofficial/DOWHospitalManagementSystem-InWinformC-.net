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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Removes The Maximize Button
            this.MaximizeBox = false;
        }
        
        private void label4_Click(object sender, EventArgs e)
        {
            //Exit The Program
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //Link for Totorial Page

            How_To_Use_Program use1 = new How_To_Use_Program();
            use1.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            //Link for Rating Form

            Rating r1 = new Rating();
            r1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //Link for Signup Page

            Signup S1 = new Signup();
            S1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Link For Login page

            Login l1 = new Login();
            l1.Show();
            this.Hide();
        }

        private void Form1_StyleChanged(object sender, EventArgs e)
        {
            
        }

        public string mk { get; set; }
    }
}
