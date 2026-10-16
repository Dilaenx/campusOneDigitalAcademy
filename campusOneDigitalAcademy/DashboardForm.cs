using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace campusOneDigitalAcademy
{
    public partial class DashboardForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=Student;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        public DashboardForm()
        {
            InitializeComponent();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            try
            {
                
                comboBox1.Items.Clear();
                comboBox1.Items.Add("Reg No");
                comboBox1.Items.Add("First Name");
                comboBox1.Items.Add("Last Name");
                comboBox1.Items.Add("NIC");
                comboBox1.Items.Add("Phone Number");
                comboBox1.SelectedIndex = 0; 

               
                LoadAllData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }

        }
        private void LoadAllData()
        {
            if (con.State == ConnectionState.Closed) con.Open();

        
            string countQuery = "SELECT COUNT(*) FROM Registration";
            SqlCommand cmdCount = new SqlCommand(countQuery, con);
            int studentCount = Convert.ToInt32(cmdCount.ExecuteScalar());
            lblTotalStudentsCount.Text = studentCount.ToString();

            string dataQuery = "SELECT * FROM Registration";
            SqlCommand cmdData = new SqlCommand(dataQuery, con);
            SqlDataAdapter da = new SqlDataAdapter(cmdData);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistrationForm regForm = new RegistrationForm();
            regForm.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalStudents_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure, Do you really want to Exit...?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (string.IsNullOrWhiteSpace(textBoxSearch.Text))
                {
                    LoadAllData();
                    return;
                }

                string query = "";
                string searchCategory = comboBox1.Text;
                string searchValue = "%" + textBoxSearch.Text + "%"; 

               
                if (searchCategory == "Reg No")
                {
                    query = "SELECT * FROM Registration WHERE CAST(regNo AS VARCHAR) LIKE @search";
                }
                else if (searchCategory == "First Name")
                {
                    query = "SELECT * FROM Registration WHERE firstName LIKE @search";
                }
                else if (searchCategory == "Last Name")
                {
                    query = "SELECT * FROM Registration WHERE lastName LIKE @search";
                }
                else if (searchCategory == "Phone Number")
                {
                    query = "SELECT * FROM Registration WHERE CAST(mobilePhone AS VARCHAR) LIKE @search OR CAST(homePhone AS VARCHAR) LIKE @search";
                }
                else if (searchCategory == "NIC")
                {
                    query = "SELECT * FROM Registration WHERE nic LIKE @search";
                }

                if (con.State == ConnectionState.Closed) con.Open();

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@search", searchValue);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt; 

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (con.State == ConnectionState.Open) con.Close();
            }

        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxSearch.Text))
            {
                LoadAllData();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
