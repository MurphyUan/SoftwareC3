using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhereAreYou
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NextPage : ContentPage
    {
        // Global variables
        char _userCourse; // 'S' - Software , 'D' - Digital Media
        char _userGroup; // A , B , C 
        int _userDay; // 1 - Monday , 2 - Tuesday , 3 - Wednesday, 4 = Thursday, 5 - Friday
        int _userTime; // 9 - 9am, 10 - 10am ........ 4 - 4pm

        // These variables to be initialised 
        string _whatRoom;
        string _whatLecture;
        string _whatTime;

        public NextPage()
        {
            InitializeComponent();
            InitializePage();
        }

        private void InitializePage()
        {
            SUIBtn.Source =
            Device.RuntimePlatform == Device.Android ? ImageSource.FromFile("SUImage.jpg")
                                                     : ImageSource.FromFile("Images/SUImage.jpg");
            GMITlibBtn.Source =
            Device.RuntimePlatform == Device.Android ? ImageSource.FromFile("GMITLibrary.jfif")
                                                     : ImageSource.FromFile("Images/GMITLibrary.jfif");
        }

        private void Btnresetpass_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new Page1());


        }

        private async void SUIBtn_Clicked(object sender, EventArgs e)
        {
            await OpenWebPage("https://gmitsu.ie/");
        }

        private async void GMITlibBtn_clicked(object sender, EventArgs e)
        {
            await OpenWebPage("https://library.gmit.ie/");
        }

        //Used to Open any webpage externally, app will resume once webpage is closed.
        public async Task<bool> OpenWebPage(String URL)
        {
            var canOpen = await Launcher.TryOpenAsync(URL);
            if (!canOpen) await DisplayAlert("Error", "Could not open webpage", "OK");
            return canOpen;
        }

        private void AddPageButton_Clicked(object sender, EventArgs e)
        {
            //Open Add Page
            Navigation.PushAsync(new AddPage());
        }

        private void EditPage_Clicked(object sender, EventArgs e)
        {
            //Open Add Page
            Navigation.PushAsync(new EditPage());
        }

        // Every time a drop down menu changes, the global variables will also change
        private void pckCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            int courseIndex = ((Picker)sender).SelectedIndex;

            if (courseIndex == 0)
            {
                _userGroup = 'S';
            }
            else{
                _userCourse = 'D';
            }   
        }

        private void pckGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            int groupIndex = ((Picker)sender).SelectedIndex;

            if (groupIndex == 0)
            {
                _userCourse = 'A';
            }
            else if (groupIndex == 1)
            {
                _userCourse = 'B';
            }
            else {
                _userCourse = 'C';
            }
        }

        private void pckDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            int dayIndex = ((Picker)sender).SelectedIndex;

            if (dayIndex == 0)
            {
                _userCourse = 'A';
            }
            else if (dayIndex == 1)
            {
                _userCourse = 'B';
            }
            else
            {
                _userCourse = 'C';
            }
        }

        private void pckTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            int timeIndex = ((Picker)sender).SelectedIndex;

            if (timeIndex == 0)
            {
                _userTime = 9;
            }
            else if (timeIndex == 1)
            {
                _userTime = 10;
            }
            else if (timeIndex == 2)
            {
                _userTime = 11;
            }
            else if (timeIndex == 3)
            {
                _userTime = 12;
            }
            else if (timeIndex == 4)
            {
                _userTime = 1;
            }
            else if (timeIndex == 5)
            {
                _userTime = 2;
            }
            else if (timeIndex == 6)
            {
                _userTime = 3;
            }
            else
            {
                _userTime = 4;
            }
        }

        private void pckDay_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int dayIndex = ((Picker)sender).SelectedIndex;

            if (dayIndex == 0)
            {
                _userDay = 1;
            }
            else if (dayIndex == 1)
            {
                _userDay = 10;
            }
            else if (dayIndex == 2)
            {
                _userDay = 11;
            }
            else if (dayIndex == 3)
            {
                _userDay = 12;
            }
            else
            {
                _userDay = 4;
            }
        }

        // Once the "WAY" button is pressed, the labels will update.
        private void BtnWAY_Clicked(object sender, EventArgs e)
        {
            LblDisplayRoom.Text = "You are in room: 101 *EXAMPLE"; // LblDisplayRoom.Text = "You are in room: " + _whatRoom;
            LblDisplayTime.Text = "At this time: 4pm - 5pm *EXAMPLE"; // LblDisplayTime.Text = "At this time: " + _whatTime;
            LblDisplayLecture.Text = "For this lecture: Project Mgmt *EXAMPLE"; //  LblDisplayLecture.Text = "For this lecture: " + _whatLecture;
        }
    }
    
}