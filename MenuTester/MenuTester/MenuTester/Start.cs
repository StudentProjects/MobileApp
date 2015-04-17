using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MenuTester
{
	public class Start : ContentPage
	{
        public Start()
        {
            var StyleB = new Style(typeof(Button))
            {
                Setters = {
                    new Setter {Property = Button.HeightRequestProperty, Value = 100},
                    new Setter {Property = Button.WidthRequestProperty, Value = 140},
                    new Setter {Property = Button.BackgroundColorProperty, Value = Color.FromHex("3399FF")}
                }
            };

            Label header = new Label
            {
                Text = "Welcome",
                HorizontalOptions = LayoutOptions.Center,
            };

            Entry username = new Entry
            {
                Placeholder = "Enter name"
            };

            Entry password = new Entry
            {
                Placeholder = "Enter password",
                IsPassword = true,
            };



            Button b1 = new Button
            {
                Text = "Login",
                Style = StyleB
            };
            b1.Clicked += async (sender, args) =>
            {
                if (username.Text == "Admin" || username.Text == "admin")
                {
                    await Navigation.PushModalAsync(new HomePage(true));
                }
                else
                    await Navigation.PushModalAsync(new HomePage(false));
            };

            Title = "Start";

            Content = new StackLayout
            {
                Padding = new Thickness(40, Device.OnPlatform(20, 0, 0), 40, 5),
                VerticalOptions = LayoutOptions.Center,
                Children = {
					header,
                    username,
                    password,
                            b1
                   
				}
            };

        }
	}
}