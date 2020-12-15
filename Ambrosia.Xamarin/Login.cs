using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Ambrosia.Xamarin.Model;
using Ambrosia.Xamarin.Views;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Ambrosia.Xamarin
{
    public partial class Login : ContentPage
    {
        bool isCreate = false;
        Entry txtFirstName;
        Entry txtLastName;
        Entry txtRePass = new Entry();

        public Login()
        {
            InitializeComponent();
            Title = "Login Page";
            NavigationPage.SetHasNavigationBar(this, false);
        }


        void btnLogin_Clicked(System.Object sender, System.EventArgs e)
        {
            btnLogin.IsEnabled = false;
            User user = new User();
            if (isCreate)
            {
                if (txtPassword.Text == txtRePass.Text
                    && txtFirstName.Text != string.Empty
                    && txtLastName.Text != string.Empty
                    && txtUsername.Text != string.Empty
                    && txtPassword.Text != string.Empty)
                {
                    user.FirstName = txtFirstName.Text;
                    user.Id = Guid.Empty;
                    user.LastName = txtLastName.Text;
                    user.Username = txtUsername.Text;
                    user.Password = txtPassword.Text;
                    InsertUser(user);
                    App.Login(user);
                    Navigation.PushAsync(new StartPage());
                }
                else
                {
                    stkUserInfo.Children.Add(new Label { Text = "Please make sure all fields have been filled and passwords match", TextColor = Color.Red });
                }
            }
            else
            {
                user.Username = txtUsername.Text;
                user.Password = txtPassword.Text;
                App.Login(user);
                if (App.user != null) Navigation.PushAsync(new StartPage());
                else
                {
                    btnCreate.Text = "Username or password is incorrect. Maybe you need an account?";
                    btnCreate.TextColor = Color.Red;
                }
            }
            btnLogin.IsEnabled = true;
        }
        private void InsertUser(User user)
        {
            HttpClient client = App.InitializeClient();

            string serializedUser = JsonConvert.SerializeObject(user);
            var content = new StringContent(serializedUser);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = client.PostAsync("User", content).Result;
            
        }


        void txtPassword_Completed(System.Object sender, System.EventArgs e)
        {
        }

        void txtUsername_Completed(System.Object sender, System.EventArgs e)
        {
        }

        void btnCreate_Clicked(System.Object sender, System.EventArgs e)
        {
            if (!isCreate)
            {
                //Navigation.PushAsync(new CreateAccount());
                stkUserInfo.Children.Add(txtRePass = new Entry
                {
                    Placeholder = "Confirm Password",
                    IsPassword = true
                }); 
                stkUserInfo.Children.Add(txtFirstName = new Entry
                {
                    Placeholder = "First Name"
                });
                stkUserInfo.Children.Add(txtLastName = new Entry
                {
                    Placeholder = "Last Name"
                });
                btnCreate.Text = "Oh wait, I do have an account";
                btnLogin.Text = "Create Account";
                isCreate = true;
            }
            else
            {
                stkUserInfo.Children.RemoveAt(4);
                stkUserInfo.Children.RemoveAt(3);
                stkUserInfo.Children.RemoveAt(2);
                btnCreate.Text = "Don't have an account? Create one!";
                btnLogin.Text = "Login";
                isCreate = false;
            }
        }
    }
}
