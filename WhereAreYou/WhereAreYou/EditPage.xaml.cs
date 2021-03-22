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
    public partial class EditPage : ContentPage
    {
        List<Schedule> schedules = new List<Schedule>();
        public EditPage()
        {
            InitializeComponent();

           

            schedules = Utils.ReadListOfData(App.filename);
        }
    }
}