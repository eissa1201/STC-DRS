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

    public partial class DoctorsSearch : ContentPage
    {
        private List<string> MyCity = new List<string>();
        private List<string> MyHospital = new List<string>();
        private List<string> MySpecialty = new List<string>();
        private List<string> ListOfDoctors = new List<string>();
        public string username;
        public DoctorsSearch(string User)
        {
            username = User;
            InitializeComponent();
            GetCity();
            GetSpecialty();
            GetHospital();
            int x = 0;
            thePicker.SelectedIndexChanged += (sender, e) =>
            {
                if (thePicker.SelectedIndex != -1)
                {
                    // Debug.WriteLine("you chose a city !");
                    thePicker2label.IsVisible = true;
                    thePicker2.IsVisible = true;
                    thePickerlabel.IsVisible = false;
                    GetHospitalWithCondition();

                }
            };


            thePicker2.SelectedIndexChanged += (sender, e) =>
            {
                if (thePicker2.SelectedIndex != -1)
                {


                    // Debug.WriteLine("you chose a city !");
                    if (x == 0)
                    {
                        thePicker3label.IsVisible = true;
                        x++;
                    }

                    thePicker3.IsVisible = true;
                    thePicker2label.IsVisible = false;
                    // GetCityWithCondition();



                }
            };


            thePicker3.SelectedIndexChanged += (sender, e) =>
            {
                if (thePicker2.SelectedIndex != -1)
                {
                    // Debug.WriteLine("you chose a city !");

                    thePicker3label.IsVisible = false;
                    // GetCityWithCondition();

                }
            };


        }










        public async void GetCity()
        {
            // here you fetch Data

            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/City?");
            message.Headers.Clear();
            message.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
            message.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");

            try
            {
                HttpResponseMessage response = await client.SendAsync(message);
                string content = await response.Content.ReadAsStringAsync();
                DataToListForCity a = JsonConvert.DeserializeObject<DataToListForCity>(content);
                foreach (var item in a.GetStringList())
                {
                    MyCity.Add(item);

                    thePicker.Items.Add(item);
                    //Debug.WriteLine(item);


                }


                // listView.ItemsSource = MyList;

            }
            catch (Exception e1)
            {
                Debug.WriteLine("cant fetch data for City");

            }
        }






        public async void GetCityWithCondition()
        {
            MyCity.Clear();
            thePicker.Items.Clear();

            // here you fetch Data
            string H = MyHospital[thePicker2.SelectedIndex];
            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/Hospital?" + WebUtility.UrlEncode("where=" + JsonConvert.SerializeObject(new DataParserForHospital() { Hospital = H })));
            message.Headers.Clear();
            message.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
            message.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");

            try
            {
                HttpResponseMessage response = await client.SendAsync(message);
                string content = await response.Content.ReadAsStringAsync();
                DataToListForCity a = JsonConvert.DeserializeObject<DataToListForCity>(content);
                foreach (var item in a.GetStringList())
                {
                    MyCity.Add(item);

                    thePicker.Items.Add(item);


                }


                // listView.ItemsSource = MyList;

            }
            catch (Exception e1)
            {
                Debug.WriteLine("cant fetch data for City");

            }
        }
        public async void GetHospital()
        {
            // here you fetch Data

            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/Hospital?");
            message.Headers.Clear();
            message.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
            message.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");

            try
            {
                HttpResponseMessage response = await client.SendAsync(message);
                string content = await response.Content.ReadAsStringAsync();
                DataToListForHospital a = JsonConvert.DeserializeObject<DataToListForHospital>(content);
                foreach (var item in a.GetStringList())
                {
                    MyHospital.Add(item);
                    thePicker2.Items.Add(item);


                }


                // listView.ItemsSource = MyList;

            }
            catch (Exception e1)
            {
                Debug.WriteLine("cant fetch data for City");

            }
        }
        public async void GetHospitalWithCondition()
        {
            MyHospital.Clear();
            thePicker2.Items.Clear();
            // here you fetch Data
            int aah = thePicker.SelectedIndex;
            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/Hospital?" + WebUtility.UrlEncode("where=" + JsonConvert.SerializeObject(new DataParserForHospital() { City = MyCity[aah] })));
            message.Headers.Clear();
            message.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
            message.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");

            try
            {
                HttpResponseMessage response = await client.SendAsync(message);
                string content = await response.Content.ReadAsStringAsync();
                DataToListForHospital a = JsonConvert.DeserializeObject<DataToListForHospital>(content);
                foreach (var item in a.GetStringList())
                {
                    MyHospital.Add(item);
                    thePicker2.Items.Add(item);


                }


                // listView.ItemsSource = MyList;

            }
            catch (Exception e1)
            {
                Debug.WriteLine("cant fetch data for City");

            }
        }

        public async void GetSpecialty()
        {
            // here you fetch Data

            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/Specialty?");
            message.Headers.Clear();
            message.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
            message.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");

            try
            {
                HttpResponseMessage response = await client.SendAsync(message);
                string content = await response.Content.ReadAsStringAsync();
                DataToListForSpecialty a = JsonConvert.DeserializeObject<DataToListForSpecialty>(content);
                foreach (var item in a.GetStringList())
                {
                    MySpecialty.Add(item);
                    thePicker3.Items.Add(item);


                }


                // listView.ItemsSource = MyList;

            }
            catch (Exception e1)
            {
                Debug.WriteLine("cant fetch data for City");

            }
        }

        public async void Picker(object sender, EventArgs args)
        {













            //    // here you Create Data



            int CityNumber = thePicker.SelectedIndex;
            int HospitalNumber = thePicker2.SelectedIndex;
            int SpecialtyNumber = thePicker3.SelectedIndex;
            if (CityNumber != -1 && HospitalNumber != -1 && SpecialtyNumber != -1)
            {

                Debug.WriteLine("city selected was " + MyCity[CityNumber]);
                Debug.WriteLine("hospital selected was " + MyHospital[HospitalNumber]);
                Debug.WriteLine("Specialty selected was " + MySpecialty[SpecialtyNumber]);

                ///////////////////////// CHECK IF DOCTOR ALREADY EXISTS
                ListOfDoctors.Clear();
                HttpClient client = new HttpClient();
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/EmployeeData?" + WebUtility.UrlEncode("where=" + JsonConvert.SerializeObject(new DataParserForEmployees() { Hospital = MyHospital[HospitalNumber], Specialty = MySpecialty[SpecialtyNumber] })));
                message.Headers.Clear();
                message.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
                message.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");

                try
                {
                    HttpResponseMessage response = await client.SendAsync(message);
                    string content = await response.Content.ReadAsStringAsync();
                    DataToListForEmployees a = JsonConvert.DeserializeObject<DataToListForEmployees>(content);
                    foreach (var item in a.GetStringList())
                    {
                        ListOfDoctors.Add(item);


                    }

                    if (ListOfDoctors.Count == 0)
                    {
                        await DisplayAlert("Problem", " No Doctor in database", "ok");
                    }
                    else
                    {

                        await Navigation.PushAsync(new Results(ListOfDoctors , username));

                    }


                    // listView.ItemsSource = MyList;

                }
                catch (Exception e1)
                {
                    Debug.WriteLine("cant fetch data for City");

                }

            }
            else if (CityNumber != -1 && HospitalNumber != -1)
            {

                ListOfDoctors.Clear();
                HttpClient client = new HttpClient();
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/EmployeeData?" + WebUtility.UrlEncode("where=" + JsonConvert.SerializeObject(new DataParserForEmployees() { Hospital = MyHospital[HospitalNumber] })));
                message.Headers.Clear();
                message.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
                message.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");

                try
                {
                    HttpResponseMessage response = await client.SendAsync(message);
                    string content = await response.Content.ReadAsStringAsync();
                    DataToListForEmployees a = JsonConvert.DeserializeObject<DataToListForEmployees>(content);
                    foreach (var item in a.GetStringList())
                    {
                        ListOfDoctors.Add(item);


                    }

                    if (ListOfDoctors.Count == 0)
                    {
                        await DisplayAlert("Problem", " No Doctor in database", "ok");
                    }
                    else
                    {

                        await Navigation.PushAsync(new Results(ListOfDoctors, username));

                    }


                    // listView.ItemsSource = MyList;

                }
                catch (Exception e1)
                {
                    Debug.WriteLine("cant fetch data for City");

                }

                //await DisplayAlert("Problem", " Must fill all the blanks", "ok");
            }
            else if (CityNumber != -1)
            {

                ListOfDoctors.Clear();
                HttpClient client = new HttpClient();
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/EmployeeData?" + WebUtility.UrlEncode("where=" + JsonConvert.SerializeObject(new DataParserForEmployees() { City = MyCity[CityNumber] })));
                message.Headers.Clear();
                message.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
                message.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");

                try
                {
                    HttpResponseMessage response = await client.SendAsync(message);
                    string content = await response.Content.ReadAsStringAsync();
                    DataToListForEmployees a = JsonConvert.DeserializeObject<DataToListForEmployees>(content);
                    foreach (var item in a.GetStringList())
                    {
                        ListOfDoctors.Add(item);


                    }

                    if (ListOfDoctors.Count == 0)
                    {
                        await DisplayAlert("Problem", " No Doctor in database", "ok");
                    }
                    else
                    {

                        await Navigation.PushAsync(new Results(ListOfDoctors, username));

                    }


                    // listView.ItemsSource = MyList;

                }
                catch (Exception e1)
                {
                    Debug.WriteLine("cant fetch data for City");

                }

                //await DisplayAlert("Problem", " Must fill all the blanks", "ok");
            }
            else
            {

                ListOfDoctors.Clear();
                HttpClient client = new HttpClient();
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/EmployeeData?");
                message.Headers.Clear();
                message.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
                message.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");

                try
                {
                    HttpResponseMessage response = await client.SendAsync(message);
                    string content = await response.Content.ReadAsStringAsync();
                    DataToListForEmployees a = JsonConvert.DeserializeObject<DataToListForEmployees>(content);
                    foreach (var item in a.GetStringList())
                    {
                        ListOfDoctors.Add(item);


                    }

                    if (ListOfDoctors.Count == 0)
                    {
                        await DisplayAlert("Problem", " No Doctor in database", "ok");
                    }
                    else
                    {

                        await Navigation.PushAsync(new Results(ListOfDoctors, username));

                    }


                    // listView.ItemsSource = MyList;

                }
                catch (Exception e1)
                {
                    Debug.WriteLine("cant fetch data for City");

                }

            }



        }
    }
}
