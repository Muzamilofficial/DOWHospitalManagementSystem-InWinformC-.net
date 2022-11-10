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
    public partial class DrAbdulFaheemENT : Form
    {
        public DrAbdulFaheemENT()
        {
            InitializeComponent();
        }

        private void DrAbdulFaheemENT_Load(object sender, EventArgs e)
        {
            // Working On DesigherLabel
            timer1.Enabled = true;
            timer1.Start();
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

        private void button6_Click(object sender, EventArgs e)
        {
            DrAbdulFaheemBookingcs dafb = new DrAbdulFaheemBookingcs();
            dafb.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DrAbdulFaheemENTNoOfDaysAvalability adc = new DrAbdulFaheemENTNoOfDaysAvalability();
            adc.Show();
            this.Hide();
        }
    }
}
