﻿using Telerik.XamarinForms.DataGrid;
using Xamarin.Forms;

namespace SDKBrowser.Examples.DataGridControl.StylingCategory.StyleSelectorExample
{
    // >> datagrid-styleselector-group
    class MyGroupSelector : DataGridStyleSelector
    {
        public DataGridStyle CountryTemplate1 { get; set; }
        public DataGridStyle CountryTemplate2 { get; set; }
        public override DataGridStyle SelectStyle(object item, BindableObject container)
        {
            GroupHeaderContext header = item as GroupHeaderContext;
            if (header != null)
            { 
                if (header.Group.Key == "India")
                {
                    return CountryTemplate1;
                }
                else
                {
                    return CountryTemplate2;
                }
            }
            return null;
        }
    }
    // << datagrid-styleselector-group
}
