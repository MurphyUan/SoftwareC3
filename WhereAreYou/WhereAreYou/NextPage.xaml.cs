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
    }
}