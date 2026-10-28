using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace campusOneDigitalAcademy
{
    public partial class Form1 : Form
    {
        
        SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=Student;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxUserName.Clear();
            textBoxPassword.Clear();
            textBoxUserName.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();
               
                string query = "SELECT COUNT(1) FROM Credentials WHERE Username = @Username COLLATE SQL_Latin1_General_CP1_CS_AS AND Password = @Password COLLATE SQL_Latin1_General_CP1_CS_AS";
               
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", textBoxUserName.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", textBoxPassword.Text.Trim());

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 1)
                {
                    DashboardForm dashForm = new DashboardForm();
                    dashForm.StartPosition = FormStartPosition.Manual;
                    dashForm.Location = this.Location;
                    dashForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Login credentials, please check Username and Password and try again", "Invalid login Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure, Do you really want to Exit...?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

    
        private void Form1_Load(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
    }
}