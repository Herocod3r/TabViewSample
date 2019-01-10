using System;
using TabViewSample.Controls;
using TabViewSample.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TabScrollView), typeof(TabScrollViewRenderer))]
namespace TabViewSample.iOS
{
    public class TabScrollViewRenderer : ScrollViewRenderer
    {
        public TabScrollViewRenderer()
        {
        }


        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            e.NewElement.PropertyChanged += NewElement_PropertyChanged;
            SetProps();
        }

        void NewElement_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            SetProps();
        }


        private void SetProps()
        {
            if (Element is null) return;
            var scroll = Element as Controls.TabScrollView;
            Bounces = scroll.IsBounceEnabled;
            ScrollEnabled = scroll.IsScrollEnabled;
        }
    }
}
