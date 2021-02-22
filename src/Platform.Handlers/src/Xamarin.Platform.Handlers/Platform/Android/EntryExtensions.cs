using Android.Text;
using Android.Widget;

namespace Xamarin.Platform
{
	public static class EntryExtensions
	{
		public static void UpdateText(this EditText editText, IEntry entry)
		{
			editText.Text = entry.Text;
		}

		public static void UpdateTextColor(this EditText editText, IEntry entry)
		{
			editText.UpdateTextColor(entry, null);
		}

		public static void UpdateTextColor(this EditText editText, IEntry entry, TextColorSwitcher? textColorSwitcher)
		{
			textColorSwitcher ??= new TextColorSwitcher(editText.TextColors);
			textColorSwitcher.UpdateTextColor(editText, entry.TextColor);
		}

		public static void UpdateIsPassword(this EditText editText, IEntry entry)
		{
			editText.SetInputType(entry);
		}

		internal static void SetInputType(this EditText editText, IEntry entry)
		{
			editText.InputType = InputTypes.ClassText;
			editText.InputType |= InputTypes.TextFlagMultiLine;

			if (entry.IsPassword && ((editText.InputType & InputTypes.ClassText) == InputTypes.ClassText))
				editText.InputType |= InputTypes.TextVariationPassword;

			if (entry.IsPassword && ((editText.InputType & InputTypes.ClassNumber) == InputTypes.ClassNumber))
				editText.InputType |= InputTypes.NumberVariationPassword;
		}
	}
}