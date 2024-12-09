using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using WindowsFormsApplication;
using System.Drawing;

namespace WindowsFormsApplication3
{
    public partial class Verified_Login : Form
    {
        string randCode;
        public static string to;

        public Verified_Login()
        {
            InitializeComponent();
            label5.Visible = false;
        }

        private void Verified_Login_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
           
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            string from, pass, messagebody;
            Random rand = new Random();
            randCode = (rand.Next(100000, 999999)).ToString();  
            MailMessage message = new MailMessage();
            to = textBox1.Text;  
            from = "cljisholin@gmail.com";  
            pass = "epub gkks gbju fiid";  

            messagebody = "Your new One-Time Password is " + randCode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messagebody;
            message.Subject = "Your Login OTP Code";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;  
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                smtp.Send(message); 
                MessageBox.Show("Code sent successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);  
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userEnteredOtp = textBox2.Text;  
            if (randCode == userEnteredOtp)
            {
          
                this.Hide();
                Form4 form4 = new Form4();
                form4.Show();
            }
            else
            {
                label5.Visible = true;
                MessageBox.Show("Wrong OTP");
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

       
        
    }
}
