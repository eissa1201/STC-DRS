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
    public partial class CreateEmployee : ContentPage
    {
        private List<string> MyCity= new List<string>();
        private List<string> MyHospital = new List<string>();
        private List<string> MySpecialty = new List<string>();
        public CreateEmployee()
        {
           
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
           string H = MyHospital[ thePicker2.SelectedIndex];
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
           int aah=  thePicker.SelectedIndex;
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
            // here you Create Data
            if (DoctorName.Text != null)
            {
                string Doctor = DoctorName.Text;
                string Doctor2 = Doctor.Trim();

                int CityNumber = thePicker.SelectedIndex;
                int HospitalNumber = thePicker2.SelectedIndex;
                int SpecialtyNumber = thePicker3.SelectedIndex;
                if (CityNumber != -1 && HospitalNumber != -1 && SpecialtyNumber != -1 && Doctor2 != "")
                {

                    Debug.WriteLine("city selected was " + MyCity[CityNumber]);
                    Debug.WriteLine("hospital selected was " + MyHospital[HospitalNumber]);
                    Debug.WriteLine("Specialty selected was " + MySpecialty[SpecialtyNumber]);

                    ///////////////////////// CHECK IF DOCTOR ALREADY EXISTS

                    HttpClient client1 = new HttpClient();
                    HttpRequestMessage message1 = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/EmployeeData?"+ JsonConvert.SerializeObject(new DataParserForEmployees() { Name = DoctorName.Text }));
                    message1.Headers.Clear();
                    message1.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
                    message1.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");

                    try
                    {
                        HttpResponseMessage response = await client1.SendAsync(message1);
                        string content = await response.Content.ReadAsStringAsync();
                        DataToListForEmployees a = JsonConvert.DeserializeObject<DataToListForEmployees>(content);
                      

                        if (a.GetStringList().Contains(DoctorName.Text))
                        {

                            await DisplayAlert("Problem", "Doctor already exists", "ok");

                            return;
                        }
                        // listView.ItemsSource = MyList;
                        
                    }
                    catch (Exception e1)
                    {
                        Debug.WriteLine("cant fetch data for City");

                    }














                    ////////////////////////////////////////////////////////////////////////////////////////////
                    HttpClient client = new HttpClient();
                    HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, "https://api.parse.com/1/classes/EmployeeData");
                    message.Headers.Clear();
                    message.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
                    message.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");
                    string json = JsonConvert.SerializeObject(new DataParserForEmployees() { Name = DoctorName.Text, Hospital = MyHospital[HospitalNumber], Specialty = MySpecialty[SpecialtyNumber], City = MyCity[CityNumber] });
                    message.Content = new StringContent(json, Encoding.UTF8, "application/json");
                    message.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    try
                    {
                        HttpResponseMessage response = await client.SendAsync(message);
                        string content = await response.Content.ReadAsStringAsync();
                        await DisplayAlert("Congratulations", DoctorName.Text + " was added to the database", "ok");
                        DoctorName.Text = "";
                    }
                    catch (Exception e1)
                    {

                    }
                }
                else
                {
                    await DisplayAlert("Problem", " Must fill all the blanks", "ok");
                }
            }
            else
            {
                await DisplayAlert("Problem", " Must fill all the blanks", "ok");
            }
        }



    }
}
