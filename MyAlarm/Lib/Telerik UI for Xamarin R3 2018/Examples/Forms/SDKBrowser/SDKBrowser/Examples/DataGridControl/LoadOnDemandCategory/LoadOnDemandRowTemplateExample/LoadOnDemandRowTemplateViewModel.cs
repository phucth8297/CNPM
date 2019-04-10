﻿using System.Collections.ObjectModel;
using SDKBrowser.ViewModels;

namespace SDKBrowser.Examples.DataGridControl.LoadOnDemandCategory.LoadOnDemandRowTemplateExample
{
    public class LoadOnDemandRowTemplateViewModel : ViewModelBase
    {
        public LoadOnDemandRowTemplateViewModel()
        {
            this.Items = new ObservableCollection<Person>();

            for (int i = 0; i < 20; i++)
            {
                var person = new Person { Name = "Person " + i, Age = i + 18, Gender = i % 2 == 0 ? Gender.Male : Gender.Female };
                this.Items.Add(person);
            }
        }

        public ObservableCollection<Person> Items { get; set; }
    }
}
