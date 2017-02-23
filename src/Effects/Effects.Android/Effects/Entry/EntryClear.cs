using Android.Runtime;
using Android.Views;
using Android.Widget;
using FormsCommunityToolkit.Effects.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(EntryClear), nameof(EntryClear))]
namespace FormsCommunityToolkit.Effects.Droid
{
    [Preserve(AllMembers = true)]
    public class EntryClear : PlatformEffect
    {
        protected override void OnAttached()
        {
            ConfigureControl();
        }

        protected override void OnDetached()
        {
            var editText = Control as EditText;

            editText?.SetOnTouchListener(null);
            editText.SetCompoundDrawablesRelativeWithIntrinsicBounds(0, 0, 0, 0);
        }

        private void ConfigureControl()
        {
            var editText = Control as EditText;
            if (editText == null)
                return;

            editText.SetCompoundDrawablesRelativeWithIntrinsicBounds(0, 0, Resource.Drawable.fct_ic_clear_icon, 0);
            editText.SetOnTouchListener(new OnDrawableTouchListener());
        }
    }

    class OnDrawableTouchListener : Java.Lang.Object, Android.Views.View.IOnTouchListener
    {
        public bool OnTouch(Android.Views.View v, MotionEvent e)
        {
            if (v is EditText && e.Action == MotionEventActions.Up)
            {
                var editText = (EditText)v;
                if (e.RawX >= (editText.Right - editText.GetCompoundDrawables()[2].Bounds.Width()))
                {
                    editText.Text = string.Empty;
                    return true;
                }
            }

            return false;
        }
    }
}