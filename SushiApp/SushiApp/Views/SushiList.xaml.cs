using System.Collections.Generic;
using SushiApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SushiApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SushiList : ContentPage
	{
		public SushiList ()
		{
            Label header= new Label
            { 
                Text = "List of sushi",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            var sushiList = new List<Sushi>
            {
                new Sushi { Name="Spicy maki", Description="Копченый лосось, авокадо, сливочный сыр", Price=1.8 },
                new Sushi { Name = "Tokyo maki", Description = "Копченый лосось, сливочный сыр, огурец", Price =1.5 },
                new Sushi { Name = "Nigiri", Description = "Морской окунь, сливочный сыр, соус Спайси", Price =2.3 },
                new Sushi { Name = "Spicy gunkan", Description = "Морской окунь, огурец, салат Айсберг", Price = 1.1},
            };

            ListView listView = new ListView
            {
                HasUnevenRows = true,
                ItemsSource = sushiList,

                ItemTemplate = new DataTemplate(() =>
                {
                    Label titleLabel = new Label { FontSize = 18 };
                    titleLabel.SetBinding(Label.TextProperty, "Name");

                    Label companyLabel = new Label() {
                        FontSize = 20
                    };
                    companyLabel.SetBinding(Label.TextProperty, "Description");

                    Label priceLabel = new Label() {
                        FontAttributes = FontAttributes.Bold,
                        FontSize = 18
                    };
                    priceLabel.SetBinding(Label.TextProperty, "Price" + " Br");

                    Image image = new Image()
                    {
                        Source = ImageSource.FromFile("b.jpg"),
                        HeightRequest = 70,
                        WidthRequest = 70
                    };

                    StackLayout mainData = new StackLayout()
                    {
                        Orientation = StackOrientation.Vertical,
                        HorizontalOptions = LayoutOptions.StartAndExpand,
                        Children = { titleLabel, companyLabel, priceLabel }
                    };

                    StackLayout secondaryData = new StackLayout()
                    {
                        Orientation = StackOrientation.Vertical,
                        WidthRequest = 100,
                        HorizontalOptions = LayoutOptions.End,
                        Children = {image}
                    };
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(20, 15),
                            Orientation = StackOrientation.Horizontal,
                            Children = { mainData, secondaryData}
                        }
                    };
                })
            };
            listView.ItemTapped += ItemTapped;
            
            this.Content = new StackLayout {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { header, listView }
            };

            async void ItemTapped(object sender, ItemTappedEventArgs e)
            {
                await Navigation.PushAsync(new OrderPage(null, e));
            }
        }
    }
}