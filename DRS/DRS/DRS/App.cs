using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace DRS
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = GetMainPage();
        }


        public Page GetMainPage()
        {


            return new NavigationPage(new WelcomePage());


        }

    }
}
