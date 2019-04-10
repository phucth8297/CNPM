﻿using System.Collections.Generic;
using Telerik.XamarinForms.Input;
using Xamarin.Forms;

namespace SDKBrowser.Examples.AutoCompleteControl.GettingStartedCategory.GettingStartedExample
{
    public class AutoCompleteGettingStartedCSharp : ContentView
    {
        public AutoCompleteGettingStartedCSharp()
        {
            // >> autocomplete-getting-started-csharp
            var autoComplete = new RadAutoComplete { Watermark = "Search here..." };
            // << autocomplete-getting-started-csharp

            autoComplete.ItemsSource = new List<string>()
            {
                "Freda Curtis",
                "Jeffery Francis",
                "Eva Lawson",
                "Emmett Santos",
                "Theresa Bryan",
                "Jenny Fuller",
                "Terrell Norris",
                "Eric Wheeler",
                "Julius Clayton",
                "Alfredo Thornton",
                "Roberto Romero",
                "Orlando Mathis",
                "Eduardo Thomas",
                "Harry Douglas"
            };

            var panel = new StackLayout();
            panel.Children.Add(autoComplete);
            this.Content = panel;
        }
    }
}