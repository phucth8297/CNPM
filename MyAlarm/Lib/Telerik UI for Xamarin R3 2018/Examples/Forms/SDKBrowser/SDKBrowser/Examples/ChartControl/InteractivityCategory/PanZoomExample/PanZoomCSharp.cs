﻿using Telerik.XamarinForms.Chart;
using Xamarin.Forms;

namespace SDKBrowser.Examples.ChartControl.InteractivityCategory.PanZoomExample
{
    public class PanZoomCSharp : ContentView
    {
        public PanZoomCSharp()
        {
            // >> chart-interactivity-panzoom-csharp
            var chart = new RadCartesianChart
            {
                BindingContext = new ViewModel(),
                PaletteName = PaletteNames.Light,
                HorizontalAxis = new DateTimeContinuousAxis
                {
                    LabelFitMode = AxisLabelFitMode.Rotate,
                    MajorStepUnit = TimeInterval.Day,
                    PlotMode = AxisPlotMode.OnTicks,
                    LabelFormat = "dd MMM",
                    MajorStep = 20,
                    ShowLabels = true
                },
                VerticalAxis = new NumericalAxis(),
                Series =
                {
                    new LineSeries
                    {
                        ValueBinding = new PropertyNameDataPointBinding("Value"),
                        CategoryBinding = new PropertyNameDataPointBinding("Date"),
                        DisplayName = "Sales"
                    }
                },
                ChartBehaviors =
                {
                    new ChartPanAndZoomBehavior()
                }
            };

            chart.Series[0].SetBinding(ChartSeries.ItemsSourceProperty, "Data");
            // << chart-interactivity-panzoom-csharp

            this.Content = chart;
        }
    }
}
