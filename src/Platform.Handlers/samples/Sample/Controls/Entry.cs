using Xamarin.Forms;
using Xamarin.Platform;

namespace Sample
{
	public class Entry : Xamarin.Forms.View, IEntry
	{
		public string Text { get; set; }

		public Color TextColor { get; set; } = Color.Default;

		public bool IsPassword { get; set; }

		public new double Width
		{
			get { return WidthRequest; }
			set { WidthRequest = value; }
		}

		public new double Height
		{
			get { return HeightRequest; }
			set { HeightRequest = value; }
		}
	}
}