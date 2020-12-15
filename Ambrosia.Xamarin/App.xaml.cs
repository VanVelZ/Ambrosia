using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using Ambrosia.Xamarin.Model;
using Ambrosia.Xamarin.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ambrosia.Xamarin
{
    public partial class App : Application
    {
        public static User user;

        public App()
        {
            InitializeComponent();
            Load();
            if (App.user != null)
                MainPage = new NavigationPage(new StartPage());
            else
                MainPage = new NavigationPage(new Login());
        }

        public static void Save()
        {
            string json = JsonConvert.SerializeObject(App.user);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filePath = Path.Combine(path, "userinfo.txt");
            using (var file = File.Open(filePath, FileMode.Create, FileAccess.Write))
            using (var strm = new StreamWriter(file))
            {
                strm.Write(json);
            }
        }

        internal static void Login(User user)
        {
            HttpClient client = InitializeClient();

            var response = client.PostAsync("User?username=" + user.Username + "&password=" + user.Password, null).Result;

            var result = response.Content.ReadAsStringAsync().Result;
            result = result.Trim('"');
            SetUserFromAPI(result);
            
            //implement the rest of the login stuff
        }

        public static void SetUserFromAPI(string id)
        {
            Guid guid = new Guid(id);
            if(guid != Guid.Empty)
            {
                var response = InitializeClient().GetAsync("User/" + id).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<User>(result);
            }
        }

        public static HttpClient InitializeClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://ambrosiaapi.azurewebsites.net/api/");
            return client;
        }
        public static void Load()
        {
            string json;
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string filePath = Path.Combine(path, "userinfo.txt");
                using (var file = File.Open(filePath, FileMode.Open, FileAccess.Read))
                using (var strm = new StreamReader(file))
                {
                    json = strm.ReadToEnd();
                }
            }
            catch
            {
                return;
            }
            App.user = JsonConvert.DeserializeObject<User>(json);
            if(App.user != null)
                SetUserFromAPI(user.Id.ToString());
            

        }
        protected override void OnStart()
        {
            Load();
        }

        protected override void OnSleep()
        {
            Save();
        }

        protected override void OnResume()
        {
            Load();
        }
    }
}
