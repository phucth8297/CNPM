﻿using System.Collections.Generic;
using Xamarin.Forms;

namespace SDKBrowser.Examples.GaugeControl.CustomizationsCategory.AxisCustomizationExample
{
    public partial class GaugeAxisCustomization : ContentView
    {
        private const string GaugeResourcePrefix = "Gauge_";

        public GaugeAxisCustomization()
        {
            this.InitializeComponent();

            int length = GaugeResourcePrefix.Length;

            foreach (KeyValuePair<string, object> pair in this.Resources)
            {
                if (pair.Key.StartsWith(GaugeResourcePrefix))
                {
                    this.pickerGauges.Items.Add(pair.Key.Remove(0, length));
                }
            }

            this.pickerGauges.SelectedIndexChanged += this.PickerGauges_SelectedIndexChanged;
        }

        private void PickerGauges_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string gaugeFullName = GaugeResourcePrefix + this.pickerGauges.Items[this.pickerGauges.SelectedIndex];
            this.contentViewGauge.Content = (View)this.Resources[gaugeFullName];
        }
    }
}
