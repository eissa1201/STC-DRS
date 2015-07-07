using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DRS
{
    public partial class CitySearch : ContentPage
    {
        public CitySearch()
        {
            InitializeComponent();
            DoctorLogic obj = new DoctorLogic();
            obj.Cell1 = "riyadh";
            obj.Cell2 = "Dammam";
            obj.Cell3 = "Mecca";
            obj.Cell4 = "khobar";
            obj.Cell5 = "jeddah";
            obj.Cell6 = "madina almonoura";
            obj.Cell7 = "taif";
            this.BindingContext = obj;
        }
        void Next(object sender, EventArgs args)
        {

            Navigation.PushAsync(new SpecialitySearch());
        }


    }
}
