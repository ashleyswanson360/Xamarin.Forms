using Xamarin.Forms;

namespace Xamarin.Platform.Handlers.DeviceTests.Stubs
{
	public partial class EntryStub : StubBase, IEntry
	{
		public string Text { get; set; }

		public Color TextColor { get; set; }

		public bool IsPassword { get; set; }
	}
}