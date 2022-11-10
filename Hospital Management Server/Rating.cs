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
    public partial class Rating : Form
    {
        public Rating()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Dislike Rating For Inserting Data Into Database

        private void label4_Click(object sender, EventArgs e)
        {
            // Calling For Rate Class
            Rate Rc = new Rate();
            Rc.display(label4_Dislike.Text, label2_Good.Text, label5_Love.Text, label6_Awesome.Text);

            // SQL Connection For Connecting Visual Studio To Database
            string CS = @"Data Source=DESKTOP-MQUTK6I\SQLEXPRESSSERVER;Initial Catalog=DOWHospitalOOPProject;Integrated Security=True";
            SqlConnection mk = new SqlConnection(CS);

            // Insert Value Into Database
            mk.Open();
            SqlCommand cmd = new SqlCommand(@"insert into Rating(Dislike)
            values(@d)", mk);
            cmd.Parameters.AddWithValue("@d", "*");
            cmd.ExecuteNonQuery();
            mk.Close();
            MessageBox.Show("Thanks For Your Review Hope You Enjoy our Service", "DOW Hospital Smart Service Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Good Rating For Inserting Data Into Database

        private void label2_Click(object sender, EventArgs e)
        {
            // Calling For Rate Class
            Rate Rc = new Rate();
            Rc.display(label4_Dislike.Text, label2_Good.Text, label5_Love.Text, label6_Awesome.Text);

            // SQL Connection For Connecting Visual Studio To Database
            string CS = @"Data Source=DESKTOP-MQUTK6I\SQLEXPRESSSERVER;Initial Catalog=DOWHospitalOOPProject;Integrated Security=True";
            SqlConnection mk = new SqlConnection(CS);

            // Insert Value Into Database
            mk.Open();
            SqlCommand cmd = new SqlCommand(@"insert into Rating(Good)
            values(@g)", mk);
            cmd.Parameters.AddWithValue("@g", "**");
            cmd.ExecuteNonQuery();
            mk.Close();
            MessageBox.Show("Thanks For Your Review Hope You Enjoy our Service", "DOW Hospital Smart Service Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Love Rating For Inserting Data Into Database

        private void label5_Click(object sender, EventArgs e)
        {
            // Calling For Rate Class
            Rate Rc = new Rate();
            Rc.display(label4_Dislike.Text, label2_Good.Text, label5_Love.Text, label6_Awesome.Text);

            // SQL Connection For Connecting Visual Studio To Database
            string CS = @"Data Source=DESKTOP-MQUTK6I\SQLEXPRESSSERVER;Initial Catalog=DOWHospitalOOPProject;Integrated Security=True";
            SqlConnection mk = new SqlConnection(CS);

            // Insert Value Into Database
            mk.Open();
            SqlCommand cmd = new SqlCommand(@"insert into Rating(Love)
            values(@lo)", mk);
            cmd.Parameters.AddWithValue("@lo", "***");
            cmd.ExecuteNonQuery();
            mk.Close();
            MessageBox.Show("Thanks For Your Review Hope You Enjoy our Service", "DOW Hospital Smart Service Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Awesome Rating For Inserting Data Into Database
        private void label6_Click(object sender, EventArgs e)
        {
            // Calling For rate Class
            Rate Rc = new Rate();
            Rc.display(label4_Dislike.Text, label2_Good.Text, label5_Love.Text, label6_Awesome.Text);

            // SQL Connection For Connecting Visual Studio To Database
            string CS = @"Data Source=DESKTOP-MQUTK6I\SQLEXPRESSSERVER;Initial Catalog=DOWHospitalOOPProject;Integrated Security=True";
            SqlConnection mk = new SqlConnection(CS);

            // Insert Value Into Database
            mk.Open();
            SqlCommand cmd = new SqlCommand(@"insert into Rating(Awesome)
            values(@a)", mk);
            cmd.Parameters.AddWithValue("@a", "****");
            cmd.ExecuteNonQuery();
            mk.Close();
            MessageBox.Show("Thanks For Your Review Hope You Enjoy our Service", "DOW Hospital Smart Service Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Link For Form 1

            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Rating_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}