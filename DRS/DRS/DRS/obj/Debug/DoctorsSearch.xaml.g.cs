//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DRS {
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    
    
    public partial class DoctorsSearch : ContentPage {
        
        private Label thePickerlabel;
        
        private Picker thePicker;
        
        private Label thePicker2label;
        
        private Picker thePicker2;
        
        private Label thePicker3label;
        
        private Picker thePicker3;
        
        private void InitializeComponent() {
            this.LoadFromXaml(typeof(DoctorsSearch));
            thePickerlabel = this.FindByName<Label>("thePickerlabel");
            thePicker = this.FindByName<Picker>("thePicker");
            thePicker2label = this.FindByName<Label>("thePicker2label");
            thePicker2 = this.FindByName<Picker>("thePicker2");
            thePicker3label = this.FindByName<Label>("thePicker3label");
            thePicker3 = this.FindByName<Picker>("thePicker3");
        }
    }
}
