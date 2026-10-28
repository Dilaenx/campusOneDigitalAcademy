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
    public partial class RegistrationForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=Student;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure, Do you really want to Exit...?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void comboBoxReg_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               
                string query = "SELECT * FROM Registration WHERE regNo=@regNo";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@regNo", int.Parse(comboBoxReg.Text));

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read()) 
                {
                    
                    textBoxFirstName.Text = dr["firstName"].ToString();
                    textBoxLastName.Text = dr["lastName"].ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(dr["dateOfBirth"]);

                   
                    if (dr["gender"].ToString() == "Male")
                    {
                        radioButtonMale.Checked = true;
                    }
                    else
                    {
                        radioButtonFemale.Checked = true;
                    }

                    textBoxAddress.Text = dr["address"].ToString();
                    textBoxEmail.Text = dr["email"].ToString();
                    textBoxMobilePhone.Text = dr["mobilePhone"].ToString();
                    textBoxHomePhone.Text = dr["homePhone"].ToString();
                    textBoxParentName.Text = dr["parentName"].ToString();
                    textBoxNIC.Text = dr["nic"].ToString();
                    textBoxContactNo.Text = dr["contactNo"].ToString();
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        private void textBoxFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonMale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonFemale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxMobilePhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxHomePhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxParentName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNIC_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxContactNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            try
            {
                string gender = "";
                if (radioButtonMale.Checked)
                {
                    gender = "Male";
                }
                else if (radioButtonFemale.Checked)
                {
                    gender = "Female";
                }

                string query = "INSERT INTO Registration VALUES (@regNo, @fName, @lName, @dob, @gender, @address, @email, @mobile, @home, @parent, @nic, @contact)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@regNo", int.Parse(comboBoxReg.Text));
                cmd.Parameters.AddWithValue("@fName", textBoxFirstName.Text);
                cmd.Parameters.AddWithValue("@lName", textBoxLastName.Text);
                cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@address", textBoxAddress.Text);
                cmd.Parameters.AddWithValue("@email", textBoxEmail.Text);
                cmd.Parameters.AddWithValue("@mobile", int.Parse(textBoxMobilePhone.Text));
                cmd.Parameters.AddWithValue("@home", int.Parse(textBoxHomePhone.Text));
                cmd.Parameters.AddWithValue("@parent", textBoxParentName.Text);
                cmd.Parameters.AddWithValue("@nic", textBoxNIC.Text);
                cmd.Parameters.AddWithValue("@contact", int.Parse(textBoxContactNo.Text));

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Record Added Successfully", "Register Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (con.State == ConnectionState.Open)
                {
                    con.Close(); 
                }
            }
            buttonClear_Click(sender, e);

            RegistrationForm_Load(sender, e);

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
          
                string gender = "";
                if (radioButtonMale.Checked)
                {
                    gender = "Male";
                }
                else if (radioButtonFemale.Checked)
                {
                    gender = "Female";
                }

                
                string query = "UPDATE Registration SET firstName=@fName, lastName=@lName, dateOfBirth=@dob, gender=@gender, address=@address, email=@email, mobilePhone=@mobile, homePhone=@home, parentName=@parent, nic=@nic, contactNo=@contact WHERE regNo=@regNo";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@regNo", int.Parse(comboBoxReg.Text));
                cmd.Parameters.AddWithValue("@fName", textBoxFirstName.Text);
                cmd.Parameters.AddWithValue("@lName", textBoxLastName.Text);
                cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@address", textBoxAddress.Text);
                cmd.Parameters.AddWithValue("@email", textBoxEmail.Text);
                cmd.Parameters.AddWithValue("@mobile", int.Parse(textBoxMobilePhone.Text));
                cmd.Parameters.AddWithValue("@home", int.Parse(textBoxHomePhone.Text));
                cmd.Parameters.AddWithValue("@parent", textBoxParentName.Text);
                cmd.Parameters.AddWithValue("@nic", textBoxNIC.Text);
                cmd.Parameters.AddWithValue("@contact", int.Parse(textBoxContactNo.Text));

                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

              
                MessageBox.Show("Record Updated Successfully", "Update Student", MessageBoxButtons.OK, MessageBoxIcon.Information); 

              
                buttonClear_Click(sender, e);
                RegistrationForm_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            comboBoxReg.Text = "";
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            dateTimePicker1.Value = DateTime.Now;
            radioButtonMale.Checked = false;
            radioButtonFemale.Checked = false;
            textBoxAddress.Clear();
            textBoxEmail.Clear();
            textBoxMobilePhone.Clear();
            textBoxHomePhone.Clear();
            textBoxParentName.Clear();
            textBoxNIC.Clear();
            textBoxContactNo.Clear();
            comboBoxReg.Focus();

            GenerateNextRegNo();
            comboBoxReg.Focus();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
          
            DialogResult result = MessageBox.Show("Are you sure, Do you really want to Delete this Record...?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question); 

            if (result == DialogResult.Yes)
            {
                try
                {
                    
                    string query = "DELETE FROM Registration WHERE regNo=@regNo";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@regNo", int.Parse(comboBoxReg.Text));

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                  
                    MessageBox.Show("Record Deleted Successfully", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information); 

                
                    buttonClear_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
            buttonClear_Click(sender, e);

            RegistrationForm_Load(sender, e);
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            try
            {
              
                comboBoxReg.Items.Clear();

                string query = "SELECT regNo FROM Registration";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

              
                while (dr.Read())
                {
                    comboBoxReg.Items.Add(dr["regNo"].ToString());
                }

                con.Close();
                GenerateNextRegNo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DashboardForm dashForm = new DashboardForm();

            dashForm.StartPosition = FormStartPosition.Manual;
            dashForm.Location = this.Location;

            dashForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();

            loginForm.StartPosition = FormStartPosition.Manual;
            loginForm.Location = this.Location;

            loginForm.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure, Do you really want to Exit...?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void GenerateNextRegNo()
        {
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();

                string query = "SELECT MAX(regNo) FROM Registration";
                SqlCommand cmd = new SqlCommand(query, con);
                object result = cmd.ExecuteScalar();

             
                if (result != DBNull.Value && result != null)
                {
                    int maxId = Convert.ToInt32(result);
                    comboBoxReg.Text = (maxId + 1).ToString(); 
                }
                else
                {
                 
                    comboBoxReg.Text = "1001";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating Registration No: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
        }
    }
}
