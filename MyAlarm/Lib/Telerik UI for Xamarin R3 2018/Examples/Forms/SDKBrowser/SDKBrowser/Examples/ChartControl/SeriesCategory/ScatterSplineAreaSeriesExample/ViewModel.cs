﻿using System.Collections.ObjectModel;

namespace SDKBrowser.Examples.ChartControl.SeriesCategory.ScatterSplineAreaSeriesExample
{
    public class ViewModel
    {
        public ObservableCollection<NumericalData> Data { get; private set; }

        public ViewModel()
        {
            this.Data = new ObservableCollection<NumericalData>(DataProvider.GetNumericData());
        }
    }
}
