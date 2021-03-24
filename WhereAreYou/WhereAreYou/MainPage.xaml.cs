using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WhereAreYou
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LblInfoDisplay.IsVisible = false;
        }

        private void BtnNextPage_Clicked(object sender, EventArgs e)
        {
            // if else to ensure user input
            if (string.IsNullOrEmpty(userName.Text) || (string.IsNullOrEmpty(userPass.Text)))
            {
                LblInfoDisplay.Text = "---- Please check both entries ----";
                LblInfoDisplay.IsVisible = true;
                return;
            }

            // Navigates to next page once login successful.
            else
            {
                Navigation.PushAsync(new NextPage());
            }
        }
    }
}
