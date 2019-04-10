﻿using System;
using Telerik.XamarinForms.Common;
using Telerik.XamarinForms.DataControls.ListView;
using Xamarin.Forms;

namespace SDKBrowser.Examples.ListViewControl.FeaturesCategory.DataOperationsExample
{
    public partial class DataOperations : ContentView
    {
        private DataOperationsViewModel vm;

        public DataOperations()
        {
            this.InitializeComponent();
            this.BindingContext =vm = new DataOperationsViewModel();
            groupSwitch.Toggled += this.GroupSwitchToggled;
            filterSwitch.Toggled += this.FilterSwitchToggled;
            sortGroupSwitch.Toggled += SortGroupSwitch_Toggled;

            sortDirectionPicker.Items.Add("no sort");
            sortDirectionPicker.Items.Add("sort by name ascending");
            sortDirectionPicker.Items.Add("sort by name descending");
            sortDirectionPicker.SelectedIndex = 0;
            sortDirectionPicker.SelectedIndexChanged += this.SortDirectionPickerSelectedIndexChanged;
        }

        private void SortGroupSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (listView.GroupDescriptors.Count > 0)
            {
                listView.GroupDescriptors.Clear();

                listView.GroupDescriptors.Add(new PropertyGroupDescriptor
                {
                    PropertyName = "Age",
                    SortOrder = sortGroupSwitch.IsToggled ? SortOrder.Descending : SortOrder.Ascending
                });
            }
        }

        private void SortDirectionPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (sortDirectionPicker.SelectedIndex)
            {
                case 0:
                    listView.SortDescriptors.Clear();
                    break;
                case 1:
                    var descriptor_Ascending = new PropertySortDescriptor { PropertyName = "Name", SortOrder = SortOrder.Ascending };
                    listView.SortDescriptors.Clear();
                    listView.SortDescriptors.Add(descriptor_Ascending);
                    break;
                case 2:
                    var descriptor_Descending = new PropertySortDescriptor { PropertyName = "Name", SortOrder = SortOrder.Descending };
                    listView.SortDescriptors.Clear();
                    listView.SortDescriptors.Add(descriptor_Descending);
                    break;
            }
        }

        private void FilterSwitchToggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                listView.FilterDescriptors.Add(new DelegateFilterDescriptor { Filter = this.Filter });
            }
            else
            {
                listView.FilterDescriptors.Clear();
            }
        }

        private bool Filter(object arg)
        {
            var age = ((Item)arg).Age;
            return age >= 25 && age <= 35;
        }

        private void GroupSwitchToggled(object sender, ToggledEventArgs e)
        {
        

            if (e.Value)
            {
                listView.GroupDescriptors.Add(new PropertyGroupDescriptor
                {
                    PropertyName = "Age",
                    SortOrder = sortGroupSwitch.IsToggled ? SortOrder.Descending : SortOrder.Ascending
                });
            }
            else
            {
                listView.GroupDescriptors.Clear();
            }
        }
    }
    }