using Plugin.LocalNotifications;
using System;
using SushiApp.Notification;
using Xamarin.Forms;
using static SushiApp.Notification.NotificationMsg;
using SushiApp.Delegates;

namespace SushiApp.Views
{
	public class Notify : ContentPage
	{
        NotificationMsg Notification = new NotificationMsg();

        public Notify ()
		{
            Notification.createMsg((int)orderStatus.Preparing);
            Notification.createMsg((int)orderStatus.Delivering);
            Notification.createMsg((int)orderStatus.Deliverered);

            Label deliver = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                Text = "Your order will be deliver at",
                FontSize = 30
            };

            string GetTime(int timeToMakeOrder)
            {
                DateTime currentTime = DateTime.Now;
                int hour = currentTime.Hour + 3;
                int minutes = currentTime.Minute;
                int orderTime = minutes + timeToMakeOrder;

                return hour.ToString() + ":" + orderTime.ToString();
            }

            Label text = new Label
            {
                
                HorizontalOptions = LayoutOptions.Center,
                Text = GetTime(3),
                FontSize = 30
            };

            StackLayout layout = new StackLayout
            {
                Children =
                {
                    deliver,
                    text
                }
            };
            
            Content = layout;
        }
	}
}