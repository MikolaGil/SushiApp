using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SushiApp.Model;

namespace SushiApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Adress : ContentPage
	{
		public Adress (Sushi data)
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
                Keyboard = Keyboard.Telephone,
                Margin = new Thickness(0, 20)
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
                string message = MakeMessage();
                bool answer = await DisplayAlert("Confirm", message, "Yes", "No");

                if (answer)
                {
                    await Navigation.PushAsync(new Notify());
                }
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

            string MakeMessage()
            {
                try
                {
                    StringBuilder message = new StringBuilder("All data correct ?\n\n");

                    message.Append("Sushi: ");
                    message.Append(data.Name + "\n");
                    message.Append("Price: ");
                    message.Append(data.Price + "$\n");
                    message.Append("City: ");
                    message.Append(cityPicker.SelectedItem);

                    return message.ToString();
                }
                catch (Exception ex)
                {
                    return "Error to get data";
                }

            }

            Content = layout;
        }
	}
}