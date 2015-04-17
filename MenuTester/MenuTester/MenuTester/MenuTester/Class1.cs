using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace MenuTester
{
	public class HomePage : MasterDetailPage
	{
		public HomePage (bool isAdmin)
		{
			// Set up masterDetailPage
			Label header = new Label {
				Text = "Start menu",
                
                
				HorizontalOptions = LayoutOptions.Center
			};

			// Have an array of all the pages names
			List<string> NamesOfPages = new List<string> ();
			NamesOfPages.Add ("Google");
			NamesOfPages.Add ("Hitta");

			if (isAdmin) {
				NamesOfPages.Add ("Aftonbladet");
				NamesOfPages.Add ("Tieto");
			}            

			//Create ListView for the master page
			ListView masterList = new ListView {   
                
				ItemsSource = NamesOfPages,
			};

			this.Master = new ContentPage {
				Title = "master",
				Content = new StackLayout {
					Children = {
						header,
						masterList
					},
				}
			};

           
			var myHomePage = new ContentPage ();
			WebView myWebView = new WebView { 
				Source = "http://www.google.com"
            
			};
			myHomePage.Content = myWebView;
			this.Detail = myHomePage;

			masterList.ItemSelected += (sender, args) => {
				this.Detail.BindingContext = args.SelectedItem;
               
             
				//put go to one of the selected pages
				if (args.SelectedItem.ToString () == "Hitta") {
					myWebView.Source = "http://www.hitta.se";
				} else if (args.SelectedItem.ToString () == "Google") {
					myWebView.Source = "http://www.google.se";
				} else if (args.SelectedItem.ToString () == "Aftonbladet") {
					myWebView.Source = "http://www.aftonbladet.se";
				} else if (args.SelectedItem.ToString () == "Tieto") {
					myWebView.Source = "http://www.tieto.se";
				}
				this.IsPresented = false;

			};


		}
        
	}
}
