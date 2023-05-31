using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BallHunter
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        Random rnd = new Random();
        Button button = new Button();
        int clicks = 0;

        private void Button_Clicked(object sender, EventArgs e)
        {
            startbutton.IsVisible = false;
            button.IsVisible = true;
            button.BackgroundColor = Color.Purple;
            button.TextColor = Color.LimeGreen;
            aLayout.Children.Add(button);
            button.Text = "Catch me";
            button.BorderWidth = 0;
            button.Clicked += running;
        }

        private async void running(object sender, EventArgs e)
        {
            clicks++;
            switch(clicks)
            {
                case 100:
                    DisplayAlert("Your", "Don't you have anything better to do?", "\"No :3\"");
                    break;
                case 250:
                    DisplayAlert("Life", "No but seriously, what's wrong with you?", "\"Nothing :3\"");
                    break;
                case 500:
                    DisplayAlert("Is", "Just quit", "\"Why though :3\"");
                    break;
                case 1000:
                    DisplayAlert("Nothing", "No more messeges after this, just leave", "\"Oh really :3\"");
                    break;
            }
            score.Text = clicks.ToString();
            double x = (double)rnd.Next((int)this.Width - (int)button.Width);
            double y = (double)rnd.Next((int)this.Height - (int)button.Width);
            double rotation = (double)rnd.Next(360);
            double scale = (double)rnd.Next(1,5);
            button.FadeTo(0, 50);
            button.RotateTo(rotation);
            button.ScaleTo(scale);
            await button.TranslateTo(x, y);
            await button.FadeTo(1);
        }
    }
}
