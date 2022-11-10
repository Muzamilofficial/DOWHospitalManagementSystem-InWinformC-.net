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
    public partial class AvalabilityOfDaysInDoctorZafarBooking : Form
    {
        public AvalabilityOfDaysInDoctorZafarBooking()
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

        // Checking Availibility Days Method

        public void DayAvailale()
        {
            if (comboBox1.Text != "")
            {
                string CS = @"Data Source=DESKTOP-MQUTK6I\SQLEXPRESSSERVER;Initial Catalog=DOWHospitalOOPProject;Integrated Security=True";
                SqlConnection mk = new SqlConnection(CS);
                SqlCommand cmd;
                string sql = "SELECT COUNT(Day) FROM DrZafarPateintBooking where Day='" + comboBox1.Text + "'";
                try
                {
                    mk.Open();
                    cmd = new SqlCommand(sql, mk);
                    Int32 rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                    Int32 bookingAvailable = Convert.ToInt32(50 - rows_count);
                    cmd.Dispose();
                    mk.Close();

                    label12.Text = "Number Of Patients Are : " + rows_count.ToString();
                    label13.Text = "Available Bookings Are : " + bookingAvailable.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (mk.State == ConnectionState.Open)
                    {
                        mk.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select Any Day", "DOW Hospital Smart Application Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label12.Text = "Select Day";
                label13.Text = "Select Day";
            }
        }

        private void AvalabilityOfDaysInDoctorZafarBooking_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Dr_Zafar dz = new Dr_Zafar();
            dz.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // Calling OF DayAvailale Method
            DayAvailale();
        }
    }
}
