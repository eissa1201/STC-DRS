using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DRS
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            SettingsLogic obj = new SettingsLogic();
            obj.Cell1 = true;
            this.BindingContext = obj;

        }

        public void statment()
        {
                SettingsLogic obj = new SettingsLogic();
                if (obj.Cell1 == true)
                {
                    obj.Cell2 = "Delete";
                }
                else
                {
                    obj.Cell2 = "Keep";
                }
                this.BindingContext = obj;
        }



    }
}
