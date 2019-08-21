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

            var sushiList = new List<ListElement>
            {
                new ListElement { Name="Spicy maki", Description="Very tasty", Price=1.8 },
                new ListElement { Name = "Tokio maki", Description = "Tokio tasty", Price =1.5 },
                new ListElement { Name = "Nigiri", Description = "I don't know what is it", Price =2.3 },
                new ListElement { Name = "Spicy gunkan", Description = "The same story", Price = 1.1},
            };

            ListView listView = new ListView
            {
                HasUnevenRows = true,
                ItemsSource = sushiList,
                
                ItemTemplate = new DataTemplate(() =>
                {
                    Label titleLabel = new Label { FontSize = 18 };
                    titleLabel.SetBinding(Label.TextProperty, "Name");
                    
                    Label companyLabel = new Label();
                    companyLabel.SetBinding(Label.TextProperty, "Description");
                    
                    Label priceLabel = new Label();
                    priceLabel.SetBinding(Label.TextProperty, "Price");

                    Image image = new Image()
                    {
                        Source = ImageSource.FromFile("b.jpg"),
                        HeightRequest = 70,
                        WidthRequest = 70,
                        HorizontalOptions = LayoutOptions.End
                    };

                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(20, 15),
                            Orientation = StackOrientation.Horizontal,
                            Children = { titleLabel, companyLabel, priceLabel, image }
                        }
                    };
                })
            };
            listView.ItemTapped += ItemTapped;
            
            this.Content = new StackLayout { Children = { header, listView } };

            async void ItemTapped(object sender, ItemTappedEventArgs e)
            {
                await Navigation.PushAsync(new OrderPage(null, e));
            }
        }
    }
}