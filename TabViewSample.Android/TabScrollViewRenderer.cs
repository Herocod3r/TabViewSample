using System;
using System.ComponentModel;
using Android.Content;
using Android.Views;
using TabViewSample.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TabViewSample.Controls.TabScrollView), typeof(TabScrollViewRenderer))]
namespace TabViewSample.Droid
{
    public class TabScrollViewRenderer : ScrollViewRenderer
    {


        public TabScrollViewRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || this.Element == null)
                return;

            if (e.OldElement != null)
                e.OldElement.PropertyChanged -= OnElementPropertyChanged;

            e.NewElement.PropertyChanged += OnElementPropertyChanged;

            SetProps();
        }

        protected void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            if (e.PropertyName == "IsBounceEnabled") SetProps();

        }




        public override bool OnInterceptTouchEvent(MotionEvent ev)
        {
            Controls.TabScrollView scroll = Element as Controls.TabScrollView;
            if (!scroll.IsScrollEnabled) ev.Action = MotionEventActions.Cancel;

            return base.OnInterceptTouchEvent(ev);


        }

        public override bool OnTouchEvent(MotionEvent ev)
        {
            Controls.TabScrollView scroll = Element as Controls.TabScrollView;
            if (!scroll.IsScrollEnabled) ev.Action = MotionEventActions.Cancel;
            return base.OnTouchEvent(ev);


        }


        private void SetProps()
        {
            Controls.TabScrollView scroll = Element as Controls.TabScrollView;

            this.HorizontalScrollBarEnabled = scroll.IsBounceEnabled;
            this.VerticalScrollBarEnabled = scroll.IsBounceEnabled;




        }
    }
}
