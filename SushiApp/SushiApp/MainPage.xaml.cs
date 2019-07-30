using SushiApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SushiApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Label mainLabel = new Label()
            {
                Text = "Welcome to Sakura Sushi!",
                TextColor = Color.FromRgb(194, 53, 66),
                FontSize = 20,
                Margin = new Thickness(0, 30),
                HorizontalOptions = LayoutOptions.Center
            };

            Image mainLogo = new Image()
            {
                Source = ImageSource.FromFile("sushi_logo.png"),
                Margin = new Thickness(5, 15),
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            Button sushiList = new Button()
            {
                Text = "Sushi List",
                CornerRadius = 10,
                TextColor = Color.FromHex("ffffff"),
                FontSize = 16,
                BackgroundColor = Color.FromRgb(194, 53, 66),
                Margin = new Thickness(45, 0),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };

            StackLayout mainLayout = new StackLayout()
            {
                Children = { mainLabel, mainLogo, sushiList }
            };
            this.Content = mainLayout;

            sushiList.Clicked += async (sender, args) => await Navigation.PushAsync(new SushiList());
        }
    }
}
