using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DRS
{
    public partial class Menu : ContentPage
    {
        public string TheName;
        public string TheEmail;

       
        public Menu(string x , string y)
        {
            InitializeComponent();
            TheName = x;
            TheEmail = y;
            Debug.WriteLine(TheName);
           use.Text = "Welcome "+ x;
            
 
            
        }
        public void moveTo (object sender, EventArgs args)
        {

             Navigation.PushAsync(new CreateEmployee());
        }
        public void FindDoctor(object sender, EventArgs args)
        {

            Navigation.PushAsync(new DoctorsSearch(TheName));
        }




    }
}
