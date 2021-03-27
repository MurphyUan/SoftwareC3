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
    public partial class EditPage : ContentPage
    {
        List<Schedule> schedules = new List<Schedule>();
        public List<string> uniqueCourses { get; set; }
        public List<int> uniqueDays { get; set; }
        public List<float> uniqueStartTimes { get; set; }

        public EditPage()
        {
            InitializeComponent();

            uniqueCourses = new List<string>();
            uniqueDays = new List<int>();
            uniqueStartTimes = new List<float>();

            List<string> DayList = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            schedules = Utils.ReadListOfData(App.filename);

            schedules.ForEach(schedule => {
                uniqueCourses.Add(schedule.Course);
                uniqueDays.Add(schedule.Day);
                uniqueStartTimes.Add(schedule.StartTime);
            });

            uniqueCourses = uniqueCourses.Distinct().ToList();
            uniqueDays = uniqueDays.Distinct().ToList();
            uniqueStartTimes = uniqueStartTimes.Distinct().ToList();

            BindingContext = this;
        }

        public void BtnSearch_Clicked(object sender, EventArgs e)
        {
            // Get selected data


            // Find corresponding record in schedules.
            //Schedule scheduleToBeEdited = schedules
            //    .Where(schedule => schedule.Course == selectedCourse)
            //    .Where(schedule => schedule.Day == selectedDay)
            //    .Where(schedule => schedule.StartTime == selectedStartTime)
            //    .First();

            // Populate Edit entry boxes with data

        }

        public void BtnSave_Clicked(object sender, EventArgs e)
        {
            //Schedule schedule = new Schedule();
            //Schedule schedule1 = new Schedule();

            //for (int x = 0; x < schedules.Count(); x++)
            //{
            //    if (schedule.Course == CEntry.Text)
            //    {
            //        schedule1 = schedule;
            //    }
            //}

        }
    }
}