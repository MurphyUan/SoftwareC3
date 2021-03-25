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
    public partial class Delete : ContentPage
    {
        int _userDay;
        public Delete()
        {
           
            InitializeComponent();
          
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

        private void Deletedata_Clicked(object sender, EventArgs e)
        {
            List<Schedule> schedules = new List<Schedule>();
            Schedule schedule = new Schedule();
            Schedule schedule1 = new Schedule();

            for (int x = 0; x < schedules.Count(); x++)
            {
                if (schedules[x].Day == pckDay.SelectedIndex + 1 &&
                    schedules[x].Course == CEntry.Text )//&&
                    
                   // (schedules[x].StartTime <= _userTime && schedules[x].EndTime > _userTime))
                {
                    schedule1 = schedule;
                    schedules.RemoveAt(x);
                    Utils.SaveListOfData(App.filename, schedules);

                }
            }
        }
    }
}