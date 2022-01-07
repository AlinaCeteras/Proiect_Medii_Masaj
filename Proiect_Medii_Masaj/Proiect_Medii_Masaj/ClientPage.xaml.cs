using Proiect_Medii_Masaj.Models;
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
    public partial class ClientPage : ContentPage
    {
        AppointmentList al;
        public ClientPage(AppointmentList alist)
        {
            InitializeComponent();
            al = alist;
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var client = (Client)BindingContext;
            await App.Database.SaveClientAsync(client);
            listView.ItemsSource = await App.Database.GetClientsAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var client = (Client)BindingContext;
            await App.Database.DeleteClientAsync(client);
            listView.ItemsSource = await App.Database.GetClientsAsync();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetClientsAsync();
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Client c;
            if (e.SelectedItem != null)
            {
                c = e.SelectedItem as Client;
                var lc = new ListClient()
                {
                    AppointmentListID = al.ID,
                    ClientID = c.ID
                };
                await App.Database.SaveListClientAsync(lc);
                c.ListClients = new List<ListClient> { lc };
                await Navigation.PopAsync();
            }
        }
    }
}