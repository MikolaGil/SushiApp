using Plugin.LocalNotifications;
using SushiApp.CustomException;
using System;

namespace SushiApp.Notification
{
    public class NotificationMsg
    {
        public int status { get; set; }
        public enum orderStatus: byte
        {
            Preparing,
            Delivering,
            Deliverered
        }

        private void Notificate(string msg, int delay)
        {
            try
            {
                CrossLocalNotifications.Current.Show("Info about delivery", msg, 101, DateTime.Now.AddSeconds(delay));
                throw new NotifyException("It works");
            }
            catch (NotifyException ex)
            {
                
            }

        }
        
        public void createMsg(int status)
        {
            switch (status)
            {
                case 0:
                    Notificate("Your order prepairing", 1);
                    break;
                case 1:
                    Notificate("Courier rides to you", 3);
                    break;
                case 2:
                    Notificate("Enjoy your meals", 5);
                    break;
            }
        }
    }
}
