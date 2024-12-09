using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 // Make sure to include this for form handling

namespace WindowsFormsApplication3
{
    class VerifiedLogin
    {
        // Method to show a login form
        internal static void Show()
        {
            // Create an instance of the LoginForm (assuming you have a LoginForm)
            Verified_Login verifiedLogin = new Verified_Login();

            // Show the login form as a dialog
            verifiedLogin.ShowDialog();
        }
    }
}
