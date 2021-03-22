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
            //Check if Schedules Exist if not create file using the Default_File
            try
            {

                Schedules = Utils.ReadListOfData(filename);

            }catch (Exception){

                Schedules = Utils.ReadListOfData(Utils.DEFAULT_FILE);
                Utils.SaveListOfData(filename, Schedules);

            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
