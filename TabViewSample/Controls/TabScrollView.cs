using System;

using Xamarin.Forms;

namespace TabViewSample.Controls
{
    public class TabScrollView : ScrollView
    {
        public static readonly BindableProperty IsScrollEnabledProperty = BindableProperty.Create(
                    "IsScrollEnabled", typeof(bool), typeof(TabScrollView), true);



        public bool IsScrollEnabled
        {
            get { return (bool)GetValue(IsScrollEnabledProperty); }
            set { SetValue(IsScrollEnabledProperty, value); }
        }




        public static readonly BindableProperty IsBounceEnabledProperty = BindableProperty.Create(
                    "IsBounceEnabled", typeof(bool), typeof(TabScrollView), true);


        public bool IsBounceEnabled
        {
            get { return (bool)GetValue(IsBounceEnabledProperty); }
            set { SetValue(IsBounceEnabledProperty, value); }
        }

    }

}

