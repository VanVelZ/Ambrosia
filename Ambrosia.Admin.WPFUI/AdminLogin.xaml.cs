using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Ambrosia.BL;
using Ambrosia.BL.Models;

namespace Ambrosia.Admin.WPFUI
{
    /// <summary>
    /// Interaction logic for AdminLogin.xaml
    /// </summary>
    public partial class AdminLogin : Window
    {
        log4net.ILog logger = log4net.LogManager.GetLogger("Utility.Logger");
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (logger.IsWarnEnabled) logger.Warn(txtUsername.Text);

            string chkUsername = txtUsername.Text;
            string chkPassword = txtPassword.Password;
            List<User> users = UserManager.Load();
            User user = users.FirstOrDefault(u => u.Username == chkUsername);

           if(user==null)
                MessageBox.Show("Invalid credentials, blow the dust outta your keyboard!!");
           else if ( (user.Username == chkUsername && user.Password == UserManager.GetHash(chkPassword) ) || (user.Username == chkUsername && user.Password == chkPassword) ) // Added or in conditional for existing logins/testing, will remove for final
            {
                MainWindow window = new MainWindow();
                window.Show();
                this.Close();
            }

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
