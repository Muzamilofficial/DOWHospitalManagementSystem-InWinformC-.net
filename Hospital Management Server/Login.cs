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
    public partial class Login : Form
    {
        // Making Public To Email And Uername For Recalling It To Another Form
        public static string PassingEmail;
        public static string PassingUsername;

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Signup s1 = new Signup();
            s1.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // Foucus On textbox4 On Form Load
            this.ActiveControl = textBox4;
            textBox4.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        //Class For Login Form

        public void Log()
        {
            // (If Condition) To Show MessageBox If Login Button Pressed Before Entry Any Data
            if (textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                // SQL Connection For Connecting Visual Studio To Database
                SqlConnection mk = new SqlConnection(@"Data Source=DESKTOP-MQUTK6I\SQLEXPRESSSERVER;Initial Catalog=DOWHospitalOOPProject;Integrated Security=True");
                SqlDataAdapter adapter = new SqlDataAdapter(@"select Email,Username,Password from SignupForm where
                Email='" + textBox4.Text + "' and Username='" + textBox5.Text + "' and Password='" + textBox6.Text + "'", mk);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Welcome To Dow Hospital Smart Application Service", "DUHS Smart Application Service", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Calling For Home Page
                    Home h1 = new Home();
                    h1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Information Please Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Fill All Information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Class For Clear The TextBox

        public void ClearTextbox()
        {
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            PassingEmail = textBox4.Text;
            PassingUsername = textBox5.Text;

            // Calling Log Class
            Log();

            // Calling Textbox Class
            ClearTextbox();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            //Link For Forget Password

            ForgetPassword fp = new ForgetPassword();
            fp.Show();
            this.Hide();
        }

        // KeyDown For TextBox 4

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Focus();
            }
        }

        // Placeholder Remove Using Leave KeyEvent For Pateint Username TextBox

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "Enter Username";
                textBox5.ForeColor = Color.Gray;
            }
        }

        // Placeholder Remove Using Leave KeyEvent For Pateint Email TextBox

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Enter Email";
                textBox4.ForeColor = Color.Gray;
            }
        }

        // Placeholder Using Enter KeyEvent For Email TextBox

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Enter Email")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }

        // Placeholder Using Enter KeyEvent For Username TextBox

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Enter Username")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.Black;
            }
        }

        // KeyDown For TextBox 5

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox6.Focus();
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
                        
        }

        private void button2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        // Key Down For Textbox 6

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.Focus();
            }
        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        // Key Up Event In Textbox 4

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                textBox4.Focus();
            }
        }

        // Key Up Event In Textbox 6

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                textBox5.Focus();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
