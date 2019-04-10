﻿using Telerik.XamarinForms.Chart;
using Xamarin.Forms;

namespace SDKBrowser.Examples.ChartControl.InteractivityCategory.TrackballSeriesExample
{
    public class TrackballSeriesCSharp : ContentView
    {
        public TrackballSeriesCSharp()
        {
            // >> chart-interactivity-trackballseries-csharp
            var chart = new RadCartesianChart
            {
                BindingContext = new ViewModel(),
                HorizontalAxis = new CategoricalAxis()
                {
                    LabelFitMode = AxisLabelFitMode.MultiLine,
                    PlotMode = AxisPlotMode.OnTicks
                },
                VerticalAxis = new NumericalAxis(),
                Series =
                {
                    new LineSeries
                    {
                        ValueBinding = new PropertyNameDataPointBinding("Value"),
                        CategoryBinding = new PropertyNameDataPointBinding("Category"),
                        DisplayName = "Sales 1"
                    },
                    new LineSeries
                    {
                        ValueBinding = new PropertyNameDataPointBinding("Value"),
                        CategoryBinding = new PropertyNameDataPointBinding("Category"),
                        DisplayName = "Sales 2"
                    }
                },
                ChartBehaviors =
                {
                    new ChartTrackBallBehavior
                    {
                        ShowIntersectionPoints = true,
                        ShowTrackInfo = true
                    }
                },
                Grid = new CartesianChartGrid
                {
                    MajorLinesVisibility = GridLineVisibility.XY,
                    MajorXLineDashArray = new[] { 4.0, 2.0 },
                    MajorYLineDashArray = new[] { 4.0, 2.0 },
                    MajorLineColor = Color.FromHex("D3D3D3"),
                    MajorLineThickness = 2
                }
            };

            chart.Series[0].SetBinding(ChartSeries.ItemsSourceProperty, "Data1");
            chart.Series[1].SetBinding(ChartSeries.ItemsSourceProperty, "Data2");
            // << chart-interactivity-trackballseries-csharp

            this.Content = chart;
        }
    }
}
