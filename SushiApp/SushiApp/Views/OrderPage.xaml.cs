using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            ListElement selectedItem = e.Item as ListElement;

            Label label = new Label
            {
                Text = "Confirm Order",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 22,
                TextColor = Color.FromHex("#a20025")
            };

            Frame nameLayout = new Frame
            {
                BorderColor = Color.FromHex("#ffffff")
            };

            nameLayout.Content = new StackLayout
            {
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
                        HorizontalOptions = LayoutOptions.StartAndExpand,
                        IsEnabled = false
                    }
                }
            };
            StackLayout descriptionLayout = new StackLayout
            {
                Children =
                {
                    new Label
                    {
                        Text = "Description",
                        FontSize = 20,
                        HorizontalOptions = LayoutOptions.Start
                    },
                    new Editor
                    {
                        Text = selectedItem.Description,
                        HorizontalOptions = LayoutOptions.StartAndExpand,
                        IsEnabled = false
                    }
                }
            };

            StackLayout priceLayout = new StackLayout
            {
                Children =
                {
                    new Label
                    {
                        Text = "Price",
                        FontSize = 20,
                        HorizontalOptions = LayoutOptions.Start
                    },
                    new Entry
                    {
                        Text = selectedItem.Price.ToString() + '$',
                        HorizontalOptions = LayoutOptions.StartAndExpand,
                        IsEnabled = false
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

            adress.Clicked += async (sender, args) => await Navigation.PushAsync(new Adress()); ;

            StackLayout layout = new StackLayout
            {

                Children =
                {
                    label,
                    nameLayout,
                    descriptionLayout,
                    priceLayout,
                    adress
                }
            };

            Content = layout;
        }
    }
}