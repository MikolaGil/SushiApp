using Plugin.LocalNotifications;
using SushiApp.Views;
using Xamarin.Forms;
using SushiApp.Extension;

namespace SushiApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            CrossLocalNotifications.Current.Show("Greetings!", "Thank you for choosing our service");

            ToolbarItem refresh = new ToolbarItem
            {
                Text = "Test",
                Priority = 0,
                Order = ToolbarItemOrder.Secondary
            };

            ToolbarItems.Add(refresh);

            Label mainLabel = new Label()
            {
                TextColor = Color.FromHex("6a00ff"),
                FontSize = 20,
                Margin = new Thickness(0, 30),
                HorizontalOptions = LayoutOptions.Center
            };

            mainLabel.Text = mainLabel.AddTrademark("Welcome to Sakura Sushi!");

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
                FontSize = 16,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("6a00ff"),
                Margin = new Thickness(45, 0),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };

            Label trademark = new Label
            {
                Text = "Mikalai Hill©",
                TextColor = Color.FromHex("9ea7aa")
            };

            StackLayout center = new StackLayout()
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center,
                Children = { mainLogo, sushiList, }
            };

            StackLayout bottom = new StackLayout()
            {
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.Center,
                Children = { trademark}
            };

            StackLayout mainLayout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { mainLabel, center, bottom }
            };
            this.Content = mainLayout;

            sushiList.Clicked += async (sender, args) => await Navigation.PushAsync(new SushiList());
        }
    }
}
