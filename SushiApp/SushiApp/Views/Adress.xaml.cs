using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SushiApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Adress : ContentPage
	{
		public Adress ()
		{
			InitializeComponent ();

            Label label = new Label
            {
                Text = "Adress",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 22,
                TextColor = Color.FromHex("#a20025")
            };

            Picker cityPicker = new Picker
            {
                Title = "Choose your city"
            };

            List<string> cityList = new List<string>();
            cityList.Add("Minsk");
            cityList.Add("Moscow");
            cityList.Add("Kiyv");

            cityPicker.ItemsSource = cityList;

            Entry district = new Entry
            {
                Placeholder = "District"
            };

            Entry street = new Entry
            {
                Placeholder = "Street",
                PlaceholderColor = Color.Olive
            };

            Entry phone = new Entry
            {
                Placeholder = "Phone",
                PlaceholderColor = Color.Olive,
                Keyboard = Keyboard.Telephone
            };

            Button confirm = new Button
            {
                Text = "Confirm Order",
                FontSize = 16,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("6a00ff"),
                Margin = new Thickness(45, 0),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };

            confirm.Clicked += ConfirmQuestion;

            async void ConfirmQuestion(object sender, EventArgs e)
            {
                bool answer = await DisplayAlert("Confirm", "All data correct?", "Yes", "No");
            }

            StackLayout layout = new StackLayout
            {
                Children =
                {
                    label,
                    cityPicker,
                    street,
                    phone,
                    confirm
                }
            };

            Content = layout;
        }
	}
}