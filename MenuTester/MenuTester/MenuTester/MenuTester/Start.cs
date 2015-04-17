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
		public Start ()
		{
			Label header = new Label {
				Text = "Navigation",
				HorizontalOptions = LayoutOptions.Center,
			};

			Button b1 = new Button {
				Text = "Admin",
				BorderWidth = 1
			};
			b1.Clicked += async (sender, args) =>
               await Navigation.PushModalAsync (new HomePage (true));

			Button b2 = new Button {
				Text = "User",
				BorderWidth = 1
			};

			b2.Clicked += async (sender, args) =>
                 await Navigation.PushModalAsync (new HomePage (false));
          
			Title = "Start";

			Content = new StackLayout {
				Children = {
					header,
					new StackLayout {
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						Children = {
							b1,
							b2
						}
					}
				}
			};
		}
	}
}