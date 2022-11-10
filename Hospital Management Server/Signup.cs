using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Hospital_Management_Server__DOW_Hospital_
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Signup_Load(object sender, EventArgs e)
        {
            // Focus On Textbox 1
            this.ActiveControl = textBox1;
            textBox1.Focus();

            // Copy Paste Controls Disabled
            ContextMenu _blankContextMenu = new ContextMenu();
            textBox1.ContextMenu = _blankContextMenu;
        }

        // Copy Paste Controls Disabled

        private const Keys CopyKeys = Keys.Control | Keys.C;
        private const Keys PasteKeys = Keys.Control | Keys.V;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((keyData == CopyKeys) || (keyData == PasteKeys))
            {
                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        } 

        private void button1_Click(object sender, EventArgs e)
        {
            // Exit The Program

            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Link For Form 1

            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        // Method For Signup Form

        public void Register()
        {
            // (If Condition) To Show MessageBox If Login Button Pressed Before Entry Any Data
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && comboBox1.Text != "" && radioButton1.Text != "" && radioButton2.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                // Checking For Duplicate Data

                // SQL Connection For Connecting Visual Studio To Database
                string CS = @"Data Source=DESKTOP-MQUTK6I\SQLEXPRESSSERVER;Initial Catalog=DOWHospitalOOPProject;Integrated Security=True";
                SqlConnection mk = new SqlConnection(CS);
                SqlDataAdapter adapter = new SqlDataAdapter(@"select Email,Username from SignupForm where
                Email='" + textBox4.Text + "' and Username='" + textBox5.Text + "'", mk);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    MessageBox.Show("Email Or Username Is Already Registered", "DOW Hospital Smart Application Service", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Login l1 = new Login();
                    l1.Show();
                    this.Hide();
                }

                //If There Is No Duplicate Data So Run The Insert Query

                else
                {
                    mk.Open();
                    SqlCommand cmd = new SqlCommand(@"insert into SignupForm(PatientName,PateintAge,MobileNumber,City,Gender,Email,Username,Password)
            values(@pn,@pa,@mn,@cy,@gen,@em,@un,@pass)", mk);

                    cmd.Parameters.AddWithValue("@pn", textBox1.Text);
                    cmd.Parameters.AddWithValue("@pa", textBox2.Text);
                    cmd.Parameters.AddWithValue("@mn", textBox3.Text);
                    cmd.Parameters.AddWithValue("@cy", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@em", textBox4.Text);
                    cmd.Parameters.AddWithValue("@un", textBox5.Text);
                    cmd.Parameters.AddWithValue("@pass", textBox6.Text);

                    if (radioButton1.Checked)
                    {

                        cmd.Parameters.AddWithValue("@gen", radioButton1.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@gen", radioButton2.Text);
                    }
                    cmd.ExecuteNonQuery();
                    mk.Close();
                    MessageBox.Show("You Sussessfully Registered In DOW Hospital Smart Application Service", "DUHS Smart Application Service", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Login l1 = new Login();
                    l1.Show();
                    this.Hide();
                }
            }
            else
            {
                this.Text = "Error";
                MessageBox.Show("Please Enter Your Full Information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Replace The Text Of Form
                this.Text = "Signup Form -----------> DOW Hospital Smart Application Service";
            }
        }

        // Class For Clear The TextBox, Combobox And RadioButton

        public void CleartextBox()
        {
            
        }
            
        //Submit Buton

        private void button2_Click(object sender, EventArgs e)
        {
            // Calling Register Method
            Register();

            //Calling Clear Method
            CleartextBox();

            // Calling Of RadioButtonChecked Method()
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        // KeyPress Validation For Age

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsDigit(ch) || ch == 8 || ch == 46)
            {
                e.Handled = false;
                button2.Enabled = true;
                label13.Text = "";
            }
            else
            {
                e.Handled = true;
                label13.Text = "Please enter valid age";
                button2.Enabled = false;
            }

            // Select All Text Inside TextBox
            if (e.KeyChar == '\x1')
            {
                label13.Text = "";
                button2.Enabled = true;
                ((TextBox)sender).SelectAll();
                e.Handled = true;
            }
        }

        // KeyPress Validation For Name

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch) || ch == 8 || ch == 46 || ch == 32)
            {
                e.Handled = false;
                button2.Enabled = true;
                label12.Text = "";
            }
            else
            {
                e.Handled = true;
                label12.Text = "Please enter valid name";
                button2.Enabled = false;
            }

            // Select All Text Inside TextBox
            if (e.KeyChar == '\x1')
            {
                label12.Text = "";
                button2.Enabled = true;
                ((TextBox)sender).SelectAll();
                e.Handled = true;
            }
        }

        // KeyPress Validation For Mobile Number

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsDigit(ch) || ch == 8 || ch == 46)
            {
                e.Handled = false;
                button2.Enabled = true;
                label14.Text = "";
            }
            else
            {
                e.Handled = true;
                label14.Text = "Invalid mobile number";
                button2.Enabled = false;
            }

            // Select All Text Inside TextBox
            if (e.KeyChar == '\x1')
            {
                label14.Text = "";
                button2.Enabled = true;
                ((TextBox)sender).SelectAll();
                e.Handled = true;
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {

        }

        // KeyLeave Validation For Email

        private void textBox4_Leave(object sender, EventArgs e)
        {
            Regex mRegxExpression;
            if (textBox4.Text.Trim() != string.Empty)
            {
                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                if (!mRegxExpression.IsMatch(textBox4.Text.Trim()))
                {
                    MessageBox.Show("Please Enter Valid Email", "DOW Hospital Smart Application Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox4.Text = "";
                    textBox4.Focus();
                }
            }

            // Placeholder Remove Using Leave KeyEvent For Email TextBox

            if (textBox4.Text == "")
            {
                textBox4.Text = "Enter Email";
                textBox4.ForeColor = Color.Gray;
            }
        }

        // Placeholder Using Enter KeyEvent For Pateint Name TextBox

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter Name")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        // Placeholder Remove Using Leave KeyEvent For Pateint Name TextBox

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Enter Name";
                textBox1.ForeColor = Color.Gray;
            }
        }

        // Placeholder Using Enter KeyEvent For Pateint Age TextBox

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Enter Age")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        // Placeholder Remove Using Leave KeyEvent For Pateint Age TextBox

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Enter Age";
                textBox2.ForeColor = Color.Gray;
            }
        }

        // Placeholder Using Enter KeyEvent For Mobile Number TextBox

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Enter Number")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        // Placeholder Removes Using Leave KeyEvent For Mobile Number TextBox

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Enter Number";
                textBox3.ForeColor = Color.Gray;
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

        // Placeholder Removes Using Leave KeyEvent For Username TextBox

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "Enter Username";
                textBox5.ForeColor = Color.Gray;
            }
        }

        // KeyDown For TextBox 1

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        // KeyDown For TextBox 2

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
            }
        }

        // KeyDown For TextBox 3

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();
            }
        }

        // KeyDown For ComboBox 1

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
            }
        }

        // KeyDown For RadioButton 1

        private void radioButton1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        // KeyDown For TextBox 4

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Focus();
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

        // KeyDown For TextBox 6

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.Focus();
            }
        }

        private void radioButton2_Leave(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {

        }

        // Key Up Event In Textbox 2

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                textBox1.Focus();
            }
        }

        // Key Up Event In Textbox 3

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                textBox2.Focus();
            }
        }

        // Key Up Event In ComboBox 1

        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                textBox3.Focus();
            }
        }

        // Key Up Event In TextBox 4

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                comboBox1.Focus();
            }
        }


        // Key Up Event In TextBox 5

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

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
        