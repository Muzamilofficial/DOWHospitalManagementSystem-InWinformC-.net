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
    public partial class Dr_zafarbillcs : Form
    {
        public Dr_zafarbillcs()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        public void BindGridView()
        {
            string CS = @"Data Source=DESKTOP-MQUTK6I\SQLEXPRESSSERVER;Initial Catalog=DOWHospitalOOPProject;Integrated Security=True";
            SqlConnection mk = new SqlConnection(CS);
            SqlDataAdapter adapter = new SqlDataAdapter(@"select * from DrZafarPateintBooking where
            Email='" + textBox1.Text + "'", mk);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

            // Adjusting All Columns In One DataGridView
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Increasing The Height Of Row
            dataGridView1.RowTemplate.Height = 100;
        }

        private void Dr_zafarbillcs_Load(object sender, EventArgs e)
        {
            // Focus On Textbox 1
            this.ActiveControl = textBox1;
            textBox1.Focus();

            // Start Timer On On Windows Load
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Calling Of BindGridView Method
            BindGridView();
        }

        private void textBox1_EnabledChanged(object sender, EventArgs e)
        {

        }


        // Email Placeholder
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter Email")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Enter Email";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
        
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                DGVPrinter printer = new DGVPrinter();
                printer.Title = "Dow Hospital Smart Application Service";
                printer.SubTitle = string.Format("\n \n Pateint Bill \n Date: {0}", DateTime.Now.Date);
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.ProportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;

                // Calculate GrandTotal
                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
                }

                printer.Footer = "The Total Payable Amount = " + sum;
                printer.FooterSpacing = 15;
                printer.PrintDataGridView(dataGridView1);
            }
            else
            {
                MessageBox.Show("Please Enter Email To Print Slip", "DOW Hospital Smart Application Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_StyleChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
            }
            MessageBox.Show(sum.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Dr_Zafar dz = new Dr_Zafar();
            dz.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rn = new Random();
            int one = rn.Next(0, 255);
            int Two = rn.Next(0, 255);
            int Three = rn.Next(0, 255);
            int Four = rn.Next(0, 255);

            label4.ForeColor = Color.FromArgb(one, Two, Three, Four);

            label4.Location = new Point(label4.Location.X + 5, label4.Location.Y);

            if (label4.Location.X > this.Width)
            {
                label4.Location = new Point(0 - label4.Width, label4.Location.Y);
            }
        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }
    }
}
