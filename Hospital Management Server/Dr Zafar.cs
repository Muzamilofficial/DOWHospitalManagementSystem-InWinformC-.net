using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;

namespace Hospital_Management_Server__DOW_Hospital_
{
    public partial class Dr_Zafar : Form
    {

        public Dr_Zafar()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home h1 = new Home();
            h1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ENT_Department ed = new ENT_Department();
            ed.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        public void Monday()
        {
            DoctorZafarClass dzc = new DoctorZafarClass();
        }


        // Booking Button
        private void button6_Click(object sender, EventArgs e)
        {
            BookinPageForIdentify book = new BookinPageForIdentify();
            book.Show();
            this.Hide();
        }

        private void Dr_Zafar_Load(object sender, EventArgs e)
        {
            // Working On DesigherLabel
            timer1.Enabled = true;
            timer1.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Emergency_Page ep = new Emergency_Page();
            ep.Show();
            this.Hide();
        }

        // Default Text In Booking Available Or Remaining Labels

        public void DafaultTextlabels()
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        // Hide Button For Booking Available Or Remaining

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        // Hide Button For Booking Available Or Remaining

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            AvalabilityOfDaysInDoctorZafarBooking qwerty = new AvalabilityOfDaysInDoctorZafarBooking();
            qwerty.Show();
            this.Hide();
        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            Dr_zafarbillcs da = new Dr_zafarbillcs();
            da.Show();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DRZafarBookingCancel dzca = new DRZafarBookingCancel();
            dzca.Show();
            this.Hide();
        }

        // Timer 1 Coding
        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rn = new Random();
            int one = rn.Next(0, 255);
            int Two = rn.Next(0, 255);
            int Three = rn.Next(0, 255);
            int Four = rn.Next(0, 255);

            DesighnLabel.ForeColor = Color.FromArgb(one, Two, Three, Four);
            label9.ForeColor = Color.FromArgb(one, Two, Three, Four);
            label11.ForeColor = Color.FromArgb(one, Two, Three, Four);

            DesighnLabel.Location = new Point(DesighnLabel.Location.X + 5, DesighnLabel.Location.Y);

            if (DesighnLabel.Location.X > this.Width)
            {
                DesighnLabel.Location = new Point(0 - DesighnLabel.Width, DesighnLabel.Location.Y);
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void DesighnLabel_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            Emergency_Page ep = new Emergency_Page();
            ep.Show();
            this.Hide();
        }
    }
}
