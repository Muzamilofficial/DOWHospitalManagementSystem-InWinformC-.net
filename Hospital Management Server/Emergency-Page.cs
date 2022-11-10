using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DGVPrinterHelper;
using System.Configuration;

namespace Hospital_Management_Server__DOW_Hospital_
{
    public partial class Emergency_Page : Form
    {
        // Making Public To Emergency Email or Recalling It To Another Form
        public static string EmergencyEmailCalling;
        public Emergency_Page()
        {
            InitializeComponent();

            // Combo Box Coding
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[]
            {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Friday"
            });
        }

        // Checking If Booking Limit Is Full So Disable The Submit Button And Show Booking Full Label
        public void DisableSubmitButton()
        {
            string CS = @"Data Source=DESKTOP-MQUTK6I\SQLEXPRESSSERVER;Initial Catalog=DOWHospitalOOPProject;Integrated Security=True";
            SqlConnection mk = new SqlConnection(CS);
            mk.Open();
            SqlCommand cmd2 = new SqlCommand("SELECT COUNT(Email) FROM ENTEmergency", mk);
            int BookingLimit = (int)cmd2.ExecuteScalar();
            cmd2.ExecuteNonQuery();
            mk.Close();
            if (BookingLimit >= 50)
            {
                button2.Enabled = false;
                label11.Text = "Sorry The Booking Is Full Try Next Week";
            }
            else
            {
                button2.Enabled = true;
            }
        }

        public void ENTEmergencyUnit()
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && comboBox1.Text != "")
            {
                // Checking For Duplicate Data

                string CS = @"Data Source=DESKTOP-MQUTK6I\SQLEXPRESSSERVER;Initial Catalog=DOWHospitalOOPProject;Integrated Security=True";
                SqlConnection mk = new SqlConnection(CS);
                SqlDataAdapter adapter = new SqlDataAdapter(@"select Email from DrZafarPateintBooking where
                Email='" + textBox1.Text + "'", mk);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Message Box If Email Is Not Available In ENTEmergency Table
                if (dt.Rows.Count >= 1)
                {
                    MessageBox.Show("Sorry This Service Is For Unregistered Or New Pateints", "DOW Hospital Smart Application Service", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                // Continue The Process If Email Is Available In ENTEmergency Table
                else
                {
                    // Checking If Email Is Available In Sighnup Table
                    mk.Open();
                    SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) FROM [SignupForm] WHERE ([Email] = @email)", mk);
                    cmd2.Parameters.AddWithValue("@email", textBox1.Text);
                    int UserExist = (int)cmd2.ExecuteScalar();
                    cmd2.ExecuteNonQuery();
                    mk.Close();

                    // If Available So Insert Day And Email In Database
                    if (UserExist > 0)
                    {
                        // Condition For Not Repaet Booking In Emergency Page

                        SqlDataAdapter adapter2 = new SqlDataAdapter(@"select Email from ENTEmergency where
                        Email='" + textBox1.Text + "'", mk);
                        DataTable dt2 = new DataTable();
                        adapter2.Fill(dt2);

                        if (dt2.Rows.Count >= 20)
                        {
                            MessageBox.Show("Email Is Already Booked", "DOW Hospital Smart Application Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            mk.Open();
                            SqlCommand cmd = new SqlCommand(@"insert into ENTEmergency(Department,PateintName,Email,DoctorName,MobileNumber,Day)
                            values(@a,@pn,@em,@dn,@mn,@d)", mk);
                            cmd.Parameters.AddWithValue("@a", "ENT");
                            cmd.Parameters.AddWithValue("@pn", textBox2.Text);
                            cmd.Parameters.AddWithValue("@em", textBox1.Text);
                            cmd.Parameters.AddWithValue("@dn", "DrZafarMahmood");
                            cmd.Parameters.AddWithValue("@mn", textBox3.Text);
                            cmd.Parameters.AddWithValue("@d", comboBox1.Text);
                            MessageBox.Show("Your Booking Is Sucessfully Booked", "DUHS Smart Application Services", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            cmd.ExecuteNonQuery();
                            label9.Enabled = true;
                            mk.Close();
                        }
                    }
                    //If Not So Display MessageBox
                    else
                    {
                        MessageBox.Show("Invalid Email Please Try Again", "DOW Hospital Smart Application Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {
                MessageBox.Show("Enter Some Data", "DOW Hospital Smart Application Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        // Enter Event For Textbox 2

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Enter Name")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        // Leave Event For Textbox 2

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Enter Name";
                textBox2.ForeColor = Color.Gray;
            }
        }

        // Keydown Event For Textbox 2

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Focus();
            }
        }

        // Enter Event For Textbox 1

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter Email")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        // Leave Event For Textbox 1

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Enter Email";
                textBox1.ForeColor = Color.Gray;
            }
        }

        // KeyDown Event For Textbox 1

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
            }
        }

        // KeyUp Event For Textbox 1

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                textBox2.Focus();
            }
        }

        // Enter Event For Textbox 3

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Enter Number")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        // Leave Event For Textbox 3

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Enter Number";
                textBox3.ForeColor = Color.Gray;
            }
        }

        // KeyDown Event For Textbox 3

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();
            }
        }

        // KeyUp Event For Textbox 3

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                textBox1.Focus();
            }
        }

        private void Emergency_Page_Load(object sender, EventArgs e)
        {
            // Focus On Textbox 2
            this.ActiveControl = textBox2;
            textBox2.Focus();

            // Start Timer On On Windows Load
            timer1.Start();

            // Disable Print Label On Form Load
            label9.Enabled = false;

            // Disable Submit Button If Booking Limit Is Full
            DisableSubmitButton();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Calling Of ENTEmergencyUnit Method
            ENTEmergencyUnit();

            // Set EmergencyEmailCalling In TextboxBox1
            EmergencyEmailCalling = textBox1.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dr_Zafar dz = new Dr_Zafar();
            dz.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // KeyPress Validation For Mobile Number

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsDigit(ch) || ch == 8 || ch == 46)
            {
                e.Handled = false;
                button2.Enabled = true;
                label6.Text = "";
            }
            else
            {
                e.Handled = true;
                label6.Text = "Invalid mobile number";
                button2.Enabled = false;
            }

            // Select All Text Inside TextBox
            if (e.KeyChar == '\x1')
            {
                label6.Text = "";
                button2.Enabled = true;
                ((TextBox)sender).SelectAll();
                e.Handled = true;
            }
        }

        // KeyDown Event For ComboBox 1

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.Focus();
            }
        }

        // KeyUp Event For ComboBox 1

        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                textBox3.Focus();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label10.Location = new Point(label10.Location.X + 5, label10.Location.Y);

            if (label10.Location.X > this.Width)
            {
                label10.Location = new Point(0 - label10.Width, label10.Location.Y);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            DRZafarPrintEmergencySlip ems = new DRZafarPrintEmergencySlip();
            ems.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}