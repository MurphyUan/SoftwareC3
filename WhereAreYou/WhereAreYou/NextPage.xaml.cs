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
        string _userCourse; // 'S' - Software , 'D' - Digital Media
        string _userGroup; // A , B , C 
        int _userDay; // 1 - Monday , 2 - Tuesday , 3 - Wednesday, 4 = Thursday, 5 - Friday
        float _userTime; // 9 - 9am, 10 - 10am ........ 4 - 4pm

        // These variables to be initialised 
        string _whatRoom;
        string _whatLecture;
        string _whatTime;

        List<Schedule> schedules = new List<Schedule>();

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
            schedules = Utils.ReadListOfData(App.filename);
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
                _userCourse = "Software Development";
            }
            else{
                _userCourse = "Digital Media";
            }   
        }

        private void pckGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            int groupIndex = ((Picker)sender).SelectedIndex;

            if (groupIndex == 0)
            {
                _userGroup = "A";
            }
            else if (groupIndex == 1)
            {
                _userGroup = "B";
            }
            else if (groupIndex == 2)
            {
                _userGroup = "C";
            }
            else _userGroup = "All";
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
                _userTime = 13;
            }
            else if (timeIndex == 5)
            {
                _userTime = 14;
            }
            else if (timeIndex == 6)
            {
                _userTime = 15;
            }
            else if (timeIndex == 7)
            {
                _userTime = 16;
            }
        }

        private void pckDay_SelectedIndexChanged(object sender, EventArgs e)
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
            
            Schedule schedule = new Schedule();
            Schedule schedule1 = new Schedule();

            for (int x = 0; x < schedules.Count();x++)
            {
                if (schedules[x].Day == pckDay.SelectedIndex + 1 &&
                    schedules[x].Course == _userCourse &&
                    schedules[x].Group == _userGroup &&
                    (schedules[x].StartTime <= _userTime && schedules[x].EndTime > _userTime))
                {
                    schedule1 = schedule;
                }
            }



            //LblDisplayRoom.Text = "You are in room: 101 *EXAMPLE"; // LblDisplayRoom.Text = "You are in room: " + _whatRoom;
            //LblDisplayTime.Text = "At this time: 4pm - 5pm *EXAMPLE"; // LblDisplayTime.Text = "At this time: " + _whatTime;
            //LblDisplayLecture.Text = "For this lecture: Project Mgmt *EXAMPLE"; //  LblDisplayLecture.Text = "For this lecture: " + _whatLecture;

            LblDisplayRoom.Text = "You Are In Room: "+schedule1.RoomID;
            LblDisplayTime.Text = "At This Time: " + schedule1.StartTime + " - " + schedule1.EndTime;
            LblDisplayLecture.Text = "For This Lecture: " + schedule1.ModuleName;
        }
    }
    
}