using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication3
{

    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        string connectionString = "Data Source=LAPTOP-6QVJ4QJ9\\SQLEXPRESS01;Initial Catalog=Test;Integrated Security=True;";

        private void Form5_Load(object sender, EventArgs e)
        {

            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            // TODO: This line of code loads data into the 'testDataSet.Ticket_Form' table. You can move, or remove it, as needed.
            this.ticket_FormTableAdapter.Fill(this.testDataSet.Ticket_Form);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            comboBox1.Focus();
            
            string query = "Exec UpdateTic";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        
     
                
              

}
}
