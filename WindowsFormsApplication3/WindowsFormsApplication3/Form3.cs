using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsFormsApplication3;
using System.Drawing;

namespace WindowsFormsApplication
{
    public partial class Form3 : Form
    {

        public Form3()
        {
            InitializeComponent();
            lblErrorMessage.Visible = false;
        }

        
        string connectionString = "Data Source=LAPTOP-6QVJ4QJ9\\SQLEXPRESS01;Initial Catalog=Test;Integrated Security=True;";
        
         private void button1_Click(object sender, EventArgs e)
        {

    
    string userName = name.Text.Trim();
    string password = pwd.Text.Trim();


    string query = "SELECT COUNT(1) FROM [dbo].[Admin_Ticket] WHERE User_Name = @UserName AND Password = @Password";
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

                UserSession1.UserName = userName;
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                Form5 form5 = new Form5();
                form5.Show();


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

         private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
         {
             this.Hide();
             Form1 form1 = new Form1();
             form1.Show();

         }


         public static class UserSession1
         {
             public static string UserName { get; set; }
         }

         private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
         {
             this.Hide();
             Form4 form4 = new Form4();
             form4.Show();

            
         }

         private void Form3_Load(object sender, EventArgs e)
         {
             panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
         }

       

       

    }
       

        }

    











 
          

 