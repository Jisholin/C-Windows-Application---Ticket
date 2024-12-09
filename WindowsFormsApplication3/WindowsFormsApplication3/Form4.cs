using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication;

namespace WindowsFormsApplication3
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            label5.Visible = false; 
        }

        string connectionString = "Data Source=LAPTOP-6QVJ4QJ9\\SQLEXPRESS01;Initial Catalog=Test;Integrated Security=True;";

        private void button1_Click(object sender, EventArgs e)
        {
      
            if (textBox2.Text == textBox3.Text)
            {
                label5.ForeColor = Color.Green;
                label5.Text = "Passwords match!";
                label5.Visible = true;  

        
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Please enter a valid Email ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

         
                        string query = "UPDATE [dbo].[Login] SET Password = @Password WHERE [Email_ID] = @EmailID";

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@Password", textBox3.Text); 
                            cmd.Parameters.AddWithValue("@EmailID", textBox1.Text);   

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Password successfully changed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Error: Password change failed. EmailID not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                  
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                label5.ForeColor = Color.Red;
                label5.Text = "Passwords do not match!";
                label5.Visible = true; 
            }
        }


       

        private void Form4_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
