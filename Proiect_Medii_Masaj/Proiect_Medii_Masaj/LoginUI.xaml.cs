using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proiect_Medii_Masaj
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginUI : ContentPage
    {
        public LoginUI()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (txtUsername.Text == "admin" && txtParola.Text == "1234")
            {
                Navigation.PushAsync(new ListEntryPage());
            }
            else
            {
                DisplayAlert("Incearca din nou!", "Username sau parola gresita!", "Ok");
            }
        }
    }
}