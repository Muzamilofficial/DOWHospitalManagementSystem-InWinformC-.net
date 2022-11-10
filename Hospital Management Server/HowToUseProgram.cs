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
    public partial class How_To_Use_Program : Form
    {
        public How_To_Use_Program()
        {
            InitializeComponent();
        }

        private void How_To_Use_Program_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
            label1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Placeholder Enter On Search Textbox
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Type to search")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        // Placeholder Leave On Search Textbox
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Type to search";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The Application Is On Developing Mode", "DOW Hospital Smart Application Service", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            textBox1.Text = "";
        }
    }
}
