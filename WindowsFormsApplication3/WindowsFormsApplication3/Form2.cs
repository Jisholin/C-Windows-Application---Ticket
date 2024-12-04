using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        string connectionString = "Data Source=LAPTOP-6QVJ4QJ9\\SQLEXPRESS01;Initial Catalog=Test;Integrated Security=True;";

        private void button1_Click(object sender, EventArgs e)
        {
            // Make sure Ticket_ID is parsed correctly
            int Ticket_ID;
            if (!int.TryParse(textBox1.Text.Trim(), out Ticket_ID))
            {
                MessageBox.Show("Please enter a valid Ticket ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string First_Name = textBox2.Text.Trim();
            string Last_Name = textBox3.Text.Trim();
            string Raised_Time = textBox4.Text.Trim();
            DateTime Raised_Date = dateTimePicker1.Value;
            string Priority = textBox5.Text.Trim();
            string Email = textBox7.Text.Trim();
            string Department = textBox8.Text.Trim();
            string Description = textBox9.Text.Trim();

            // Fix the closing parenthesis for the validation check
            if (string.IsNullOrEmpty(First_Name) || string.IsNullOrEmpty(Last_Name) ||
                string.IsNullOrEmpty(Priority) || string.IsNullOrEmpty(Email) ||
                string.IsNullOrEmpty(Department) || string.IsNullOrEmpty(Description) ||
                string.IsNullOrEmpty(Raised_Time))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"INSERT INTO [Test].[dbo].[Ticket_Form] (Ticket_ID, First_Name, Last_Name, Raised_Time, Raised_Date, Priority, 
                            Email, Department, Description)
                             VALUES (@Ticket_ID, @First_Name, @Last_Name, @Raised_Time, @Raised_Date, @Priority, 
                             @Email, @Department, @Description)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Use the integer Ticket_ID here
                    command.Parameters.AddWithValue("@Ticket_ID", Ticket_ID);
                    command.Parameters.AddWithValue("@First_Name", First_Name);
                    command.Parameters.AddWithValue("@Last_Name", Last_Name);
                    command.Parameters.AddWithValue("@Raised_Time", Raised_Time);
                    command.Parameters.AddWithValue("@Raised_Date", Raised_Date);
                    command.Parameters.AddWithValue("@Priority", Priority);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Department", Department);
                    command.Parameters.AddWithValue("@Description", Description);

                    try
                    {
                        connection.Open();

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Ticket inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("An error occurred while inserting the ticket.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
}
