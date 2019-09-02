using System;
using SushiApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SushiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderPage : ContentPage
    {

        public OrderPage(EventArgs ev, ItemTappedEventArgs e)
        {
            Sushi selectedItem = e.Item as Sushi;

            Label label = new Label
            {
                Text = "Confirm Order",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 22,
                TextColor = Color.FromHex("#a20025")
            };

            Frame name = new Frame
            {
                BorderColor = Color.FromHex("#ffffff"),
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Children = {
                    new Label
                    {
                        Text = "Name",
                        FontSize = 20,
                        HorizontalOptions = LayoutOptions.Start
                    },
                    new Entry
                    {
                        Text = selectedItem.Name,
                        HorizontalOptions = LayoutOptions.EndAndExpand,
                        IsEnabled = false
                    }
                }
                }
            };

            Frame description = new Frame
            {
                BorderColor = Color.FromHex("#ffffff"),
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Children = {
                        new Label
                        {
                            Text = "Description",
                            FontSize = 20,
                            WidthRequest = 110,
                            HorizontalOptions = LayoutOptions.Center
                        },
                        new Editor
                        {
                            Text = selectedItem.Description,
                            HorizontalOptions = LayoutOptions.StartAndExpand,
                            IsEnabled = false
                        }
                    }
                }
            };

            Frame price = new Frame
            {
                BorderColor = Color.FromHex("#ffffff"),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Children = {
                        new Label
                        {
                            Text = "Price",
                            FontSize = 20,
                            HorizontalOptions = LayoutOptions.Start
                        },
                        new Entry
                        {
                            Text = selectedItem.Price.ToString() + '$',
                            HorizontalOptions = LayoutOptions.EndAndExpand,
                            IsEnabled = false
                        }
                    }
                }
            };

            Button adress = new Button
            {
                Text = "Add Adress",
                FontSize = 16,
                TextColor = Color.White,
                CornerRadius = 10,
                BackgroundColor = Color.FromHex("6a00ff"),
                Margin = new Thickness(45, 0),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };

            adress.Clicked += async (sender, args) => await Navigation.PushAsync(new Adress(selectedItem)); ;

            StackLayout layout = new StackLayout
            {

                Children =
                {
                    label,
                    name,
                    price,
                    description,
                    adress
                }
            };

            Content = layout;
        }
    }
}