﻿using SushiApp.Views;
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
                TextColor = Color.FromHex("6a00ff"),
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
                FontSize = 16,
                WidthRequest = 120,
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
                Children = { mainLabel, center, bottom }
            };
            this.Content = mainLayout;

            sushiList.Clicked += async (sender, args) => await Navigation.PushAsync(new SushiList());
        }
    }
}
