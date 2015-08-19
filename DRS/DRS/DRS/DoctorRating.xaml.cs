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

    public partial class DoctorRating : ContentPage
    {
        private List<string> ListOfUsers = new List<string>();
        private List<string> CommentsCollector = new List<string>();
        private List<string> TheDoctor = new List<string>();
        private string usernameToComment;
        private string TheNameToComment;
        public DoctorRating(string TheName, string Username)
        {
            InitializeComponent();

            WriteComment.IsEnabled = false;
            WriteComment.IsVisible = false;

            TitleOfComment.IsEnabled = false;
            TitleOfComment.IsVisible = false;
           

            Comment.IsEnabled = false;
            Comment.IsVisible = false;


            usernameToComment = Username;

            TheNameToComment = TheName;



            DoctorInformation(TheName);


            GetComments();
        }

        public async void DoctorInformation(string TheName)
        {

            TheDoctor.Clear();
            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/EmployeeData?" + WebUtility.UrlEncode("where=" + JsonConvert.SerializeObject(new DataParserForEmployees() { Name = TheName })));
            message.Headers.Clear();
            message.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
            message.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");

            try
            {
                HttpResponseMessage response = await client.SendAsync(message);
                string content = await response.Content.ReadAsStringAsync();
                DataToListForEmployeesForRating a = JsonConvert.DeserializeObject<DataToListForEmployeesForRating>(content);
                foreach (var item in a.GetStringList())
                {
                    TheDoctor.Add(item);


                }

                if (TheDoctor.Count == 0)
                {
                    await DisplayAlert("Problem", " No Doctor in database", "ok");
                }
                else
                {

                    DoctorName.Text = " Name : " + TheDoctor[0];
               
                    SpecialtyName.Text = " Speciality : " + TheDoctor[2];

                    CityName.Text = "\n City : " + TheDoctor[1];



                    if (TheDoctor[3] == "5")
                    {



                    }
                    else if (TheDoctor[3] == "4")
                    {
                        star4.IsVisible = false;


                    }
                    else if (TheDoctor[3] == "3")
                    {

                        star4.IsVisible = false;
                        star3.IsVisible = false;

                    }
                    else if (TheDoctor[3] == "2")
                    {

                        star4.IsVisible = false;
                        star3.IsVisible = false;
                        star2.IsVisible = false;
                    }
                    else
                    {

                        star4.IsVisible = false;
                        star3.IsVisible = false;
                        star2.IsVisible = false;
                        star1.IsVisible = false;



                    }
                }


         

            }
            catch (Exception e1)
            {
                Debug.WriteLine("cant fetch data for City");

            }



        }


        public async void GetComments()
        {

            // here you fetch Data
            //ListOfUsers.Clear();
            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/EmployeeRating?" + WebUtility.UrlEncode("where=" + JsonConvert.SerializeObject(new DataParserForUserRating() { Name = TheNameToComment })));
            message.Headers.Clear();
            message.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
            message.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");

            try
            {
                HttpResponseMessage response = await client.SendAsync(message);
                string content = await response.Content.ReadAsStringAsync();
                DataToListForUserRating a = JsonConvert.DeserializeObject<DataToListForUserRating>(content);
                foreach (var item in a.GetStringList())
                {
                    CommentsCollector.Add(item);

                }

                for (int i = 0; i < a.GetStringList().Count / 2; i++)
                {

                    string Commenter = CommentsCollector[i + i] + " : \n" + CommentsCollector[i + i + 1] + "\n";
                    ListOfUsers.Add(Commenter);
                }

                listView.ItemsSource = ListOfUsers;
            


            }
            catch (Exception e1)
            {
                Debug.WriteLine("cant fetch data for comments");

            }
        }



         void GoComment(object sender, EventArgs args)
        {

             

           

            StartCommenting.IsEnabled = false;
           StartCommenting.IsVisible = false;

            DoctorName.IsEnabled = false;
            DoctorName.IsVisible = false;

            SpecialtyName.IsEnabled = false;
            SpecialtyName.IsVisible = false;

            CityName.IsEnabled = false;
            CityName.IsVisible = false;

            star0.IsEnabled = false;
            star0.IsVisible = false;

            star1.IsEnabled = false;
            star1.IsVisible = false;

            star2.IsEnabled = false;
            star2.IsVisible = false;

            star3.IsEnabled = false;
            star3.IsVisible = false;

            star4.IsEnabled = false;
            star4.IsVisible = false;

            listView.IsEnabled = false;
            listView.IsVisible = false;




            TitleOfComment.IsEnabled = true;
            TitleOfComment.IsVisible = true;


            Comment.IsEnabled = true;
            Comment.IsVisible = true;


            WriteComment.IsEnabled = true;
            WriteComment.IsVisible = true;


        }
        async void PostComment(object sender, EventArgs args)
        {

            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, "https://api.parse.com/1/classes/EmployeeRating");
            message.Headers.Clear();
            message.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
            message.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");
            string json = JsonConvert.SerializeObject(new DataParserForUserRating() { Name = TheNameToComment, Username = usernameToComment, Comments = Comment.Text });
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");
            message.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            try
            {
                HttpResponseMessage response = await client.SendAsync(message);
                string content = await response.Content.ReadAsStringAsync();
                await DisplayAlert("Congratulations", " Your Comment Has Been Posted !", "ok");
                LeaveComment();

              
            
            }
            catch (Exception e1)
            {

            }
    

        }

        void LeaveComment()
        {





            StartCommenting.IsEnabled = true;
            StartCommenting.IsVisible = true;

            DoctorName.IsEnabled = true;
            DoctorName.IsVisible = true;

            SpecialtyName.IsEnabled = true;
            SpecialtyName.IsVisible = true;

            CityName.IsEnabled = true;
            CityName.IsVisible = true;

            star0.IsEnabled = true;
            star0.IsVisible = true;

            star1.IsEnabled = true;
            star1.IsVisible = true;

            star2.IsEnabled = true;
            star2.IsVisible = true;

            star3.IsEnabled = true;
            star3.IsVisible = true;

            star4.IsEnabled = true;
            star4.IsVisible = true;

            listView.IsEnabled = true;
            listView.IsVisible = true;

            TitleOfComment.IsEnabled = false;
            TitleOfComment.IsVisible = false;

            Comment.IsEnabled = false;
            Comment.IsVisible = false;

            WriteComment.IsEnabled = false;
            WriteComment.IsVisible = false;


        }



    }
}

