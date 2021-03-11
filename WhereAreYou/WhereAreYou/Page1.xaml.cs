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
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Reset_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(newuserPass.Text) || (string.IsNullOrEmpty(newuserPass2.Text)))
            {
                LblInfoDisplay.Text = "---- Please check both entries ----";
                LblInfoDisplay.IsVisible = true;
                return;
            }

            // Navigates to next page once login successful
            else
            {
                LblInfoDisplay.Text = "Password changed!";
                LblInfoDisplay.IsVisible = true;
            }
        }
    }
}