using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MenuTester
{
    public class HomePage : MasterDetailPage
    {
        public HomePage()
        {
            // Set up masterDetailPage
            Label header = new Label
            {
                Text = "Start menu",
                
                Font = Font.SystemFontOfSize(NamedSize.Medium)
                             .WithAttributes(FontAttributes.Bold),
                
                HorizontalOptions = LayoutOptions.Center
            };

            // Have an array of all the pages names
            string[] NamesOfPages = 
            {
             "Google",
             "Hitta",
            };

            //Create ListView for the master page
            ListView masterList = new ListView
            {   
                
                ItemsSource = NamesOfPages,
            };

            this.Master = new ContentPage
            {
                Title = "master",
                Content = new StackLayout
                {
                    Children =
                    {
                        header,
                        masterList
                    },
                }
            };

            string[] homePageItems = { "Google", "Hitta"};
            ListView myHomeView = new ListView
            {
                ItemsSource = homePageItems,
            };
            var myHomePage = new ContentPage();
            WebView myWebView = new WebView
            { 
                 Source = "http://www.google.com"
            
            };
            myHomePage.Content = myWebView;
            this.Detail = myHomePage;

            masterList.ItemSelected += (sender, args) =>
            {
                this.Detail.BindingContext = args.SelectedItem;
               
                
             
                //put go to one of the selected pages
                if (args.SelectedItem.ToString() == "Hitta")
                {
                    myWebView.Source = "http://www.hitta.se";
                }
                else if (args.SelectedItem.ToString() == "Google") 
                {
                    myWebView.Source = "http://www.google.se";
                }
                this.IsPresented = false;

            };
            Label myHomeHeader = new Label
            {
                Text = "Home",
                HorizontalOptions = LayoutOptions.Center
            };


        }
        
        //protected override void OnStart()
        //{
        //    // Handle when your app starts
        //}

        //protected override void OnSleep()
        //{
        //    // Handle when your app sleeps
        //}

        //protected override void OnResume()
        //{
        //    // Handle when your app resumes
        //}
    }
}
