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
    public partial class DRZafarBookingCancel : Form
    {
        public DRZafarBookingCancel()
        {
            InitializeComponent();

            // Combo Box Coding
            textBox1.Text = Login.PassingEmail;
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

        // Email Placeholder
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter Email")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        // Email Leave On Placeholder
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Enter Email";
                textBox1.ForeColor = Color.Gray;
            }
        }

        // Keydown On Email Textbox
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        // Name Placeholder
        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Enter Name")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        // Name Leave Placeholder
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Enter Name";
                textBox2.ForeColor = Color.Gray;
            }
        }

        // Keydown Event On textbox

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();
            }
        }

        // Keyup Event On Textbox

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                comboBox1.Focus();
            }
        }

        // Keydown Event On Combobox

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();
            }
        }

        private void DRZafarBookingCancel_Load(object sender, EventArgs e)
        {
            // Focus On Textbox 1
            this.ActiveControl = textBox2;
            textBox2.Focus();

            // Calling Of AutoGridView
            AutoGridView();

            // Working On DesigherLabel
            timer1.Enabled = true;
            timer1.Start();
        }

        // Update Button Coding
        public void UpdateRecord()
        {
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "")
            {
                string CS = @"Data Source=DESKTOP-MQUTK6I\SQLEXPRESSSERVER;Initial Catalog=DOWHospitalOOPProject;Integrated Security=True";
                SqlConnection mk = new SqlConnection(CS);
                string query = "update DrZafarPateintBooking set Day=@dy where Name=@n";
                SqlCommand cmd = new SqlCommand(query, mk);
                cmd.Parameters.AddWithValue("@n", textBox2.Text);
                cmd.Parameters.AddWithValue("@dy", comboBox1.Text);
                mk.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("The Data Is Updated Sucessfully", "Dow Hospital Service", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetGridview();
                }
                else
                {
                    MessageBox.Show("Please Enter Same Valid Name", "Dow Hospital Service", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                mk.Close();
            }
            else
            {
                MessageBox.Show("Please Enter All Information", "Dow Hospital Smart Application Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Delete Button Coding
        public void DeleteRecord()
        {
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "")
            {
                string CS = @"Data Source=DESKTOP-MQUTK6I\SQLEXPRESSSERVER;Initial Catalog=DOWHospitalOOPProject;Integrated Security=True";
                SqlConnection mk = new SqlConnection(CS);
                string query = @"delete from DrZafarPateintBooking where Email=@em and Name=@n and Day=@dy";
                SqlCommand cmd = new SqlCommand(query, mk);
                cmd.Parameters.AddWithValue("@em", textBox1.Text);
                cmd.Parameters.AddWithValue("@n", textBox2.Text);
                cmd.Parameters.AddWithValue("@dy", comboBox1.Text);
                mk.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Your Booking On Is Been Cancelled", "Dow Hospital Smart Application Service", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetGridview();
                }
                else
                {
                    MessageBox.Show("Your Entered Information Not Match Our Records", "Dow Hospital Smart Application Service", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                mk.Close();
            }
            else
            {
                MessageBox.Show("Please Enter All Information", "Dow Hospital Smart Application Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Automatically Show GridView Of Current Email Which User Login
        public void AutoGridView()
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

        // Show Table On GridView By This Method
        public void BindGridView()
        {
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "")
            {
                string CS = @"Data Source=DESKTOP-MQUTK6I\SQLEXPRESSSERVER;Initial Catalog=DOWHospitalOOPProject;Integrated Security=True";
                SqlConnection mk = new SqlConnection(CS);
                SqlDataAdapter adapter = new SqlDataAdapter(@"select * from DrZafarPateintBooking where
                Email='" + textBox1.Text + "' and Name='" + textBox2.Text + "' and Day='" + comboBox1.Text + "'", mk);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

                // Adjusting All Columns In One DataGridView
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Increasing The Height Of Row
                dataGridView1.RowTemplate.Height = 100;
            }
            else
            {
                MessageBox.Show("Please Fill All TextBoxes To Continue This Operetaion", "Dow Hospital Smart Application Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        public void ResetGridview()
        {
            AutoGridView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Calling Of ResetGridview Method To Reset Dafault Grid View And Show All Booking Which Booked On This Email
            ResetGridview();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Calling Of DeleteRecord Method To Delete Record
            DeleteRecord();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Dr_Zafar dz = new Dr_Zafar();
            dz.Show();
            this.Hide();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Calling Of UpdateRecord Method()
            UpdateRecord();
        }

        // Timer 1 Coding
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            Random rn = new Random();
            int one = rn.Next(0, 255);
            int Two = rn.Next(0, 255);
            int Three = rn.Next(0, 255);
            int Four = rn.Next(0, 255);

            label4.ForeColor = Color.FromArgb(one, Two, Three, Four);
            label5.ForeColor = Color.FromArgb(one, Two, Three, Four);
            label6.ForeColor = Color.FromArgb(one, Two, Three, Four);
        }
    }
}