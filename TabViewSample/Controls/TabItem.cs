using System;

using Xamarin.Forms;

namespace TabViewSample.Controls
{
    public class TabItem : ContentView
    {
        public TabItem()
        {
           
        }

        public static readonly BindableProperty HeaderTextProperty = BindableProperty.Create(
                    "HeaderText", typeof(string), typeof(TabItem), "");



        public string HeaderText
        {
            get { return (string)GetValue(HeaderTextProperty); }
            set { SetValue(HeaderTextProperty, value); }
        }
    }
}

