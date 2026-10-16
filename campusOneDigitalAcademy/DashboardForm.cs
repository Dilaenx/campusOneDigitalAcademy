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
                con.Open();

             
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
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
                if (con.State == System.Data.ConnectionState.Open) con.Close();
            }
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
    }
}
