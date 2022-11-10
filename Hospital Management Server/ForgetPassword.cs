using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hospital_Management_Server__DOW_Hospital_
{
    public partial class ForgetPassword : Form
    {
        public ForgetPassword()
        {
            InitializeComponent();
        }

        public void clean()
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        // Password reset Method To reset Password From Database
        public void Password()
        {
            // (If Condition) To Show MessageBox If Login Button Pressed Before Entry Any Data
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                // Checking For Duplicate Data

                // SQL Connection For Connecting Visual Studio To Database
                string CS = @"Data Source=DESKTOP-MQUTK6I\SQLEXPRESSSERVER;Initial Catalog=DOWHospitalOOPProject;Integrated Security=True";
                SqlConnection mk = new SqlConnection(CS);
                SqlDataAdapter adapter = new SqlDataAdapter(@"select Password from SignupForm where
                Username='" + textBox1.Text + "' and Email='" + textBox2.Text + "'", mk);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

                // Adjusting All Columns In One DataGridView
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Increasing The Height Of Row
                dataGridView1.RowTemplate.Height = 100;
            }
            else
            {
                MessageBox.Show("Please Enter Email Or Username", "DOW Hospital Smart Application Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            Password();
            clean();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void ForgetPassword_Load(object sender, EventArgs e)
        {
            // Focus On Textbox 1
            this.ActiveControl = textBox2;
            textBox2.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // Email Placeholder
        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Enter Email")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        // Email Leave On Placeholder
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Enter Email";
                textBox2.ForeColor = Color.Gray;
            }
        }

        // Keydown On Email Textbox
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Focus();
            }
        }

        // Name Placeholder
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter Username")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        // Name Leave Placeholder
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Enter Username";
                textBox1.ForeColor = Color.Gray;
            }
        }

        // Keydown Event On textbox
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.Focus();
            }
        }

        // Keydown Event On Textbox
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                textBox2.Focus();
            }
        }
    }
}
