using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsFormsApplication3;

namespace WindowsFormsApplication
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            lblErrorMessage.Visible = false;
        }

        
        string connectionString = "Data Source=LAPTOP-6QVJ4QJ9\\SQLEXPRESS01;Initial Catalog=Test;Integrated Security=True;";
         private void button1_Click_1(object sender, EventArgs e)
        {

    
    string userName = name.Text.Trim();
    string password = pwd.Text.Trim();

    
    string query = "SELECT COUNT(1) FROM [dbo].[Login] WHERE User_Name = @UserName AND Password = @Password";
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@UserName", userName);
        cmd.Parameters.AddWithValue("@Password", password);
        
        try
        {
            conn.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count == 1)
            {

                UserSession.UserName = userName;
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                Form2 form2 = new Form2();
                form2.Show();


            }
            else
            {

                lblErrorMessage.Visible = true;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}

       

    }
       

        }
public static class UserSession
{
    public static string UserName { get; set; }
}


      
            
    

