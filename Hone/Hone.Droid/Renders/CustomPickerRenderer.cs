
using Android.Views;
using Hone.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(Picker),typeof(CustomPickerRenderer))]
namespace Hone.Droid.Renders
{
    public class CustomPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);   
            if(e.OldElement == null)
            {
                Picker element = (Picker)this.Element;
                var nativePicker = (global::Android.Widget.TextView)Control;
                element.BackgroundColor = Color.Blue;
                nativePicker.SetBackgroundColor(element.BackgroundColor.ToAndroid());
                
              
            }
        }
    }
}