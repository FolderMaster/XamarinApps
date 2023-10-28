using Android.OS;
using Android.Runtime;
using static Android.Preferences.Preference;

namespace CustomViewApp
{
    public class SavedViewsContainerState : BaseSavedState
    {
        public int ViewsCount { get; set; }

        public SavedViewsContainerState(IParcelable state, int viewsCount) : base(state) =>
            ViewsCount = viewsCount;

        public override void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
        {
            base.WriteToParcel(dest, flags);
            dest.WriteInt(ViewsCount);
        }
    }
}