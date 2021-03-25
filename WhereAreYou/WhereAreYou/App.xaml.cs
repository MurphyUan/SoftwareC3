using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhereAreYou
{
    public partial class App : Application
    {
        public List<Schedule> Schedules = new List<Schedule>();
        public const string filename = "Schedule.json";

        public App()
        {
            InitializeComponent();

            // MainPage = new MainPage(); // This is only for single page applications
            MainPage = new NavigationPage(new MainPage()); // Use this for multipage application, also state starting page
        }

        protected override void OnStart()
        {
            // ********** I had to comment out the below, It really doesn't like ln 32 in Utils.cs, I also didn't want to mess wit your stuff here ***************

            //Check if Schedules Exist if not create file using the Default_File

            

            Utils.SaveListOfData(filename, Schedules);
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
