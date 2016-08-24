
using System;
using System.Collections;
using Xamarin.Forms;

namespace Hone.Controles
{
    public partial class BindablePicker : Picker
    {
        public BindablePicker()
        {
            //InitializeComponent();
            this.SelectedIndexChanged += OnSelectedIndexChanged;
            
        }

        public static BindableProperty ItemsSourceProperty =
            BindableProperty.Create<BindablePicker, IList>(o => o.ItemsSource, default(IList), propertyChanged: OnItemsSourceChanged);

        public static BindableProperty SelectedItemProperty =
            BindableProperty.Create<BindablePicker, object>(o => o.SelectedItem, default(object), propertyChanged: UpdateSelected);


        public string DisplayMember { get; set; }

        public IList ItemsSource
        {
            get { return (IList)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        private static void OnItemsSourceChanged(BindableObject bindable, IList oldvalue, IList newvalue)
        {
            var picker = bindable as BindablePicker;

            if (picker != null)
            {
                picker.Items.Clear();

                if (newvalue == null) return;

                foreach (var item in newvalue)
                {
                    if (string.IsNullOrEmpty(picker.DisplayMember))
                    {
                        picker.Items.Add(item.ToString());
                    }
                    else
                    {
                        picker.Items.Add(picker.DisplayMember);
                    }
                }

            }
        }

        private void OnSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            if (SelectedIndex < 0 || SelectedIndex > Items.Count - 1)
            {
                SelectedItem = null;
            }
            else
            {
                SelectedItem = ItemsSource[SelectedIndex];
            }
        }

        private static void UpdateSelected(BindableObject bindable, object oldvalue, object newvalue)
        {

            var picker = bindable as BindablePicker;
            if (picker != null)
                if (picker.ItemsSource != null)
                    if (picker.ItemsSource.Contains(picker.SelectedItem))
                        picker.SelectedIndex = picker.ItemsSource.IndexOf(picker.SelectedItem);
                    else
                        picker.SelectedIndex = -1;

        }
    }
}
