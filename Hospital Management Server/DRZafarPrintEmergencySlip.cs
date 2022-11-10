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
    public partial class DRZafarPrintEmergencySlip : Form
    {
        public DRZafarPrintEmergencySlip()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Emergency_Page ep = new Emergency_Page();
            ep.Show();
            this.Hide();
        }

        public void BindGridView()
        {
            string CS = @"Data Source=DESKTOP-MQUTK6I\SQLEXPRESSSERVER;Initial Catalog=DOWHospitalOOPProject;Integrated Security=True";
            SqlConnection mk = new SqlConnection(CS);
            SqlDataAdapter adapter = new SqlDataAdapter(@"select * from ENTEmergency where
            Email='" +Emergency_Page.EmergencyEmailCalling+ "'", mk);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

            // Adjusting All Columns In One DataGridView
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Increasing The Height Of Row
            dataGridView1.RowTemplate.Height = 100;
        }

        // Print The Emergency Slip 
        private void button1_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Dow Hospital Smart Application Service";
            printer.SubTitle = string.Format("\n \n Pateint Emergency Booking Slip \n Date: {0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.ProportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Pakistan First Smart Application By Muzamil Khan";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView1);
        }

        private void DRZafarPrintEmergencySlip_Load(object sender, EventArgs e)
        {
            // Load Grid View On Form Load
            BindGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
