using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhereAreYou
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        List<Schedule> schedules = new List<Schedule>();
        public AddPage()
        {
            InitializeComponent();

            List<string> DayList = new List<string>();

            DayList.Add("Monday");
            DayList.Add("Tuesday");
            DayList.Add("Wednesday");
            DayList.Add("Thursday");
            DayList.Add("Friday");

            DPick.ItemsSource = DayList;

            schedules = Utils.ReadListOfData(NextPage.filename);
        }

        private void PushBtn_Clicked(object sender, EventArgs e)
        {
            Schedule schedule = new Schedule();
            schedule.ModuleName = MNEntry.Text;
            schedule.RoomID = RIDEntry.Text;
            schedule.Day = DPick.ItemsSource[DPick.SelectedIndex]+"";
            schedule.StartTime = float.Parse(STEntry.Text);
            schedule.EndTime = float.Parse(ETEntry.Text);

            schedules.Add(schedule);
            Utils.SaveListOfData(NextPage.filename,schedules);
        }

        private void ClearBtn_Clicked(object sender, EventArgs e)
        {
            MNEntry.Text = "";
            RIDEntry.Text = "";
            DPick.SelectedIndex = -1;
            STEntry.Text = "";
            ETEntry.Text = "";
        }

        private void ExitBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NextPage());
        }
    }
}