﻿using Telerik.XamarinForms.DataGrid;
using Xamarin.Forms;

namespace SDKBrowser.Examples.DataGridControl.StylingCategory.StyleSelectorExample
{
    // >> datagrid-styleselector-celldecoration
    class MyCellDecorationSelector : DataGridStyleSelector
    {
        public DataGridStyle CellTemplate1 { get; set; }
        public DataGridStyle CellTemplate2 { get; set; }
        public override DataGridStyle SelectStyle(object item, BindableObject container)
        {
            DataGridCellInfo cellInfo = item as DataGridCellInfo;
            if (cellInfo != null)
            {
                if ((cellInfo.Item as Data).Capital == "Singapore")
                {
                    return CellTemplate1;
                }
                else
                {
                    return CellTemplate2;
                }
            }
            return base.SelectStyle(item, container);
        }
    }
    // << datagrid-styleselector-celldecoration
}
