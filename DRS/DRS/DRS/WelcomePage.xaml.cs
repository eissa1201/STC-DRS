using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Diagnostics;


using System.IO;
using System.Net.Http.Headers;

namespace DRS
{
    public partial class WelcomePage : ContentPage
    {
       
        public List<string> MyList = new List<string>();
        public WelcomePage()
        {
            InitializeComponent();
        }



        private async void Login(object sender, EventArgs args)
        {



            if (!(String.IsNullOrEmpty(EntryTitle.Text) || String.IsNullOrEmpty(EntryTitle2.Text)))
            {
                // here you fetch Data
                HttpClient client = new HttpClient();
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/UserData?" + WebUtility.UrlEncode("where=" + JsonConvert.SerializeObject(new DataParser() { Email = EntryTitle.Text, Password = EntryTitle2.Text  })));
                message.Headers.Clear();
                message.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
                message.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");
  
                    HttpResponseMessage response = await client.SendAsync(message);
                    string content = await response.Content.ReadAsStringAsync();
                    DataToList a = JsonConvert.DeserializeObject<DataToList>(content);

                    foreach (var item in a.GetStringList())
                    {
                        MyList.Add(item);
                    }


                  
                    if (a.GetStringList().Contains(EntryTitle.Text))
                    {
                        await Navigation.PushAsync(new Menu(MyList[1], MyList[0]));
                        MyList.Clear();

                    }
                    else
                    {
                        await DisplayAlert("Problem", "Wrong Username or Password!", "ok");
                    }


            }
            else
            {

                await DisplayAlert("Problem", "Fill in the blanks", "ok");
            }




        }

     
        void Registration(object sender, EventArgs args)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
