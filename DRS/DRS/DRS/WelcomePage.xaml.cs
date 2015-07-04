﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DRS
{
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        void SignIn(object sender, EventArgs args)
        {
            Navigation.PushAsync(new CitySearch());
        }
        void Registration(object sender, EventArgs args)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
