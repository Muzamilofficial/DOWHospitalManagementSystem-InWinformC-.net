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
    public partial class DrAbdulFaheemBookingcs : Form
    {
        public static int GrandTotal;
        public DrAbdulFaheemBookingcs()
        {
            InitializeComponent();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Location = new Point(label5.Location.X + 5, label5.Location.Y);

            if (label5.Location.X > this.Width)
            {
                label5.Location = new Point(0 - label5.Width, label5.Location.Y);
            }
        }

        private void DrAbdulFaheemBookingcs_Load(object sender, EventArgs e)
        {
            // Login Form Email Validation On textbox
            textBox1.Text = Login.PassingEmail;

            // Focus On Textbox 1
            this.ActiveControl = textBox2;
            textBox2.Focus();

            // Timer Start On Form Load
            timer1.Start();
        }

        // Booking Method

        public void Booking()
        {
            if (textBox1.Text != "" && comboBox1.Text != "" && textBox2.Text != "")
            {
                // Initializing Class Of Method

                DrAbdulFaheemClass dzcf = new DrAbdulFaheemClass();
                dzcf.PateintEmail = textBox1.Text;
                dzcf.PateintName = textBox2.Text;
                dzcf.PateintDay = comboBox1.Text;

                string CS = @"Data Source=DESKTOP-MQUTK6I\SQLEXPRESSSERVER;Initial Catalog=DOWHospitalOOPProject;Integrated Security=True";
                SqlConnection mk = new SqlConnection(CS);
                SqlDataAdapter adapter2 = new SqlDataAdapter(@"select Day from DrAbdulFaheemBooking where
                Day='" + comboBox1.Text + "'", mk);
                DataTable dt2 = new DataTable();
                adapter2.Fill(dt2);
                if (dt2.Rows.Count > 50)
                {
                    MessageBox.Show("The Booking Is Full On " + comboBox1.Text, "DOW Hospital Application Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Checking If Email Is Available In DrZafarPateintBooking Table
                    SqlDataAdapter adapter = new SqlDataAdapter(@"select Email from DrAbdulFaheemBooking where
                    Email='" + textBox1.Text + "'", mk);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Message Box If Email Is Not Available In DrZafarPateintBooking Table
                    if (dt.Rows.Count >= 2)
                    {
                        MessageBox.Show("Only 2 Times Booking Is Alloed In A Week", "DOW Hospital Smart Application Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Hide();
                        Dr_Zafar da = new Dr_Zafar();
                        da.Show();
                    }

                    // Continue The Process If Email Is Available In DrZafarPateintBooking Table
                    else
                    {
                        int a = 800;
                        int b = 200;
                        GrandTotal = a + b;
                        mk.Open();
                        SqlCommand cmd = new SqlCommand(@"insert into DrAbdulFaheemBooking(Name,Email,DoctorName,Day,DoctorFees,MiscCharges,TotalAmount)
                        values(@n,@em,@dn,@dy,@DF,@misc,@total)", mk);
                        cmd.Parameters.AddWithValue("@n", textBox2.Text);
                        cmd.Parameters.AddWithValue("@em", textBox1.Text);
                        cmd.Parameters.AddWithValue("@dn", "Dr-AbdulFaheem");
                        cmd.Parameters.AddWithValue("@dy", comboBox1.Text);
                        cmd.Parameters.AddWithValue("@DF", a);
                        cmd.Parameters.AddWithValue("@misc", b);
                        cmd.Parameters.AddWithValue("@total", GrandTotal);

                        MessageBox.Show("Your Booking Is Sucessfully Booked", "DUHS Smart Application Services", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        Dr_Zafar da = new Dr_Zafar();
                        da.Show();
                        this.Enabled = false;
                        cmd.ExecuteNonQuery();
                        mk.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Enter Name Or Day To Continue", "DOW Hospital Smart Application Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Calling Of Booking Class
            Booking();
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
                button2.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrAbdulFaheemENT dz = new DrAbdulFaheemENT();
            dz.Show();
            this.Hide();
        }
    }
}
