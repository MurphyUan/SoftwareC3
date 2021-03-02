using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhereAreYou
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // MainPage = new MainPage(); // This is only for single page applications
            MainPage = new NavigationPage(new MainPage()); // Use this for multipage application, also state starting page
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
