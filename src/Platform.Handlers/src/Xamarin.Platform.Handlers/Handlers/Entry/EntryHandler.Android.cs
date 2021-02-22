using Android.Widget;

namespace Xamarin.Platform.Handlers
{
	public partial class EntryHandler : AbstractViewHandler<IEntry, EditText>
	{
		static TextColorSwitcher? TextColorSwitcher { get; set; }

		protected override EditText CreateNativeView()
		{
			return new EditText(Context);
		}

		protected override void SetupDefaults(EditText nativeView)
		{
			base.SetupDefaults(nativeView);

			TextColorSwitcher = new TextColorSwitcher(nativeView.TextColors);
		}

		public static void MapText(EntryHandler handler, IEntry entry)
		{
			ViewHandler.CheckParameters(handler, entry);

			handler.TypedNativeView?.UpdateText(entry);
		}

		public static void MapTextColor(EntryHandler handler, IEntry entry)
		{
			ViewHandler.CheckParameters(handler, entry);

			handler.TypedNativeView?.UpdateTextColor(entry, TextColorSwitcher);
		}

		public static void MapIsPassword(EntryHandler handler, IEntry entry)
		{
			ViewHandler.CheckParameters(handler, entry);

			handler.TypedNativeView?.UpdateIsPassword(entry);
		}
	}
}