using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect_Medii_Masaj.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proiect_Medii_Masaj
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var alist = (AppointmentList)BindingContext;
            alist.Date = DateTime.UtcNow;
            await App.Database.SaveAppointmentListAsync(alist);
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var alist = (AppointmentList)BindingContext;
            await App.Database.DeleteAppointmentListAsync(alist);
            await Navigation.PopAsync();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var appointmentl = (AppointmentList)BindingContext;

            listView.ItemsSource = await App.Database.GetListClientsAsync(appointmentl.ID);
        }
        async void OnChooseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ClientPage((AppointmentList)
           this.BindingContext)
            {
                BindingContext = new Client()
            });
        }
    }
}