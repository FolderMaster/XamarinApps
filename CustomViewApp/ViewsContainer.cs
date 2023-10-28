using Android.Content;
using Android.OS;
using Android.Util;
using Android.Widget;

namespace CustomViewApp
{
    public class ViewsContainer : LinearLayout
    {
        private int _viewsCount = 0;

        public ViewsContainer(Context context) : base(context) { }

        public ViewsContainer(Context context, IAttributeSet attributeSet) : base(context, attributeSet) { }

        public void IncrementViews()
        {
            var textView = new TextView(Context);
            textView.SetText((_viewsCount++).ToString(), TextView.BufferType.Normal);
            AddView(textView);
        }

        protected override IParcelable OnSaveInstanceState()
        {
            var state = new SavedViewsContainerState(base.OnSaveInstanceState(), _viewsCount);
            return state;
        }

        protected override void OnRestoreInstanceState(IParcelable state)
        {
            if(!(state is SavedViewsContainerState))
            {
                base.OnRestoreInstanceState(state);
                return;
            }
            var s = (SavedViewsContainerState)state;
            base.OnRestoreInstanceState(state);
            for(var i = 0; i < s.ViewsCount; ++i)
            {
                IncrementViews();
            }
        }
    }
}