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
    
    
    public partial class WelcomePage : ContentPage {
        
        private Entry EntryTitle;
        
        private Entry EntryTitle2;
        
        private void InitializeComponent() {
            this.LoadFromXaml(typeof(WelcomePage));
            EntryTitle = this.FindByName<Entry>("EntryTitle");
            EntryTitle2 = this.FindByName<Entry>("EntryTitle2");
        }
    }
}
