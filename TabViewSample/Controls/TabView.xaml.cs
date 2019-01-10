using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace TabViewSample.Controls
{
    public partial class TabView : ContentView
    {
        TapGestureRecognizer tgr;
        public TabView()
        {
            InitializeComponent();
            ItemSource = new List<TabItem>();
            InitializeComponent();

            tgr = new TapGestureRecognizer();
            tgr.Tapped += Tgr_Tapped;
        }

        void Tgr_Tapped(object sender, EventArgs e)
        {
            SelectedIndex = head.Children.IndexOf(sender as View);
        }



        double width = 0;
        protected override void LayoutChildren(double x, double y, double width, double height)
        {

            this.width = width;
            base.LayoutChildren(x, y, width, height);
            foreach (var item in body.Children)
            {
                item.WidthRequest = width;
            }
            InvalidateMeasure();



        }

        protected override void OnParentSet()
        {
            base.OnParentSet();
            //var w = ((Parent as View).Parent as View).Width;
            InitViews();
        }


        protected async override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(SelectedIndex))
            {
                if (width < 1) return;
                if (head.Children.Count < 1) return;
                if (SelectedIndex >= head.Children.Count) return;


                // var oldItem = ItemSource.ElementAt(lastIndex);
                head.Children.Clear();
                int i = 0;
                foreach (var item in ItemSource)
                {

                    object headerTemplate = null;
                    if (i == SelectedIndex) Resources.TryGetValue("checked", out headerTemplate);
                    else Resources.TryGetValue("unchecked", out headerTemplate);

                    var itemHeader = (headerTemplate as DataTemplate).CreateContent() as StackLayout;

                    var lb = itemHeader.Children[0] as Label;



                     lb.Text = item.HeaderText;
                    itemHeader.GestureRecognizers.Add(tgr);
                    head.Children.Add(itemHeader);
                    i++;
                }

                if (Device.RuntimePlatform == Device.iOS)
                {
                    await scroll.ScrollToAsync(width * SelectedIndex, 0, true);
                }
                else
                {
                    await scroll.ScrollToAsync(width * SelectedIndex, 0, false);
                }

            }
            else if (propertyName == nameof(ItemSource))
            {
                InitViews();
            }


        }



        private void InitViews()
        {

            if (ItemSource is null || ItemSource.Count < 1) return;

            //if (width == 0) return;
            head.Children.Clear();
            body.Children.Clear();
            object headerTemplate;

            int i = 0;
            foreach (var item in ItemSource)
            {

                var content = new ContentView
                {
                    WidthRequest = 335,
                    Content = item
                };




               if(SelectedIndex == i) Resources.TryGetValue("checked", out headerTemplate);
               else Resources.TryGetValue("unchecked", out headerTemplate);

                var itemHeader = (headerTemplate as DataTemplate).CreateContent() as StackLayout;
               
                var lb = itemHeader.Children[0] as Label;



                lb.Text = item.HeaderText;
                itemHeader.GestureRecognizers.Add(tgr);

                head.Children.Add(itemHeader);
                body.Children.Add(content);

                i++;
            }
           
        }







        public static readonly BindableProperty ItemSourceProperty = BindableProperty.Create(
                    "ItemSource", typeof(List<TabItem>), typeof(TabView), null);


        public List<TabItem> ItemSource
        {
            get { return (List<TabItem>)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }


        public static readonly BindableProperty SelectedIndexProperty = BindableProperty.Create(
                    "SelectedIndex", typeof(int), typeof(TabView), 0);


        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }
    }
}
