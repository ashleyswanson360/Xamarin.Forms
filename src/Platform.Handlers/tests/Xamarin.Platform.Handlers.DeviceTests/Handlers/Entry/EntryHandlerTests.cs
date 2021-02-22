using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Platform.Handlers.DeviceTests.Stubs;
using Xunit;

namespace Xamarin.Platform.Handlers.DeviceTests
{
	public partial class EntryHandlerTests : HandlerTestBase<EntryHandler>
	{
		[Fact(DisplayName = "Is Text Initializes Correctly")]
		public async Task TextInitializesCorrectly()
		{
			var entry = new EntryStub()
			{
				Text = "Test"
			};

			await ValidatePropertyInitValue(entry, () => entry.Text, GetNativeText, entry.Text);
		}

		[Fact(DisplayName = "Is TextColor Initializes Correctly")]
		public async Task TextColorInitializesCorrectly()
		{
			var entry = new EntryStub()
			{
				Text = "Test",
				TextColor = Color.Yellow
			};

			await ValidatePropertyInitValue(entry, () => entry.TextColor, GetNativeTextColor, entry.TextColor);
		}

		[Fact(DisplayName = "Is IsPassword Initializes Correctly")]
		public async Task IsPasswordInitializesCorrectly()
		{
			var entry = new EntryStub()
			{
				IsPassword = true
			};

			await ValidatePropertyInitValue(entry, () => entry.IsPassword, GetNativeIsPassword, entry.IsPassword);
		}
	}
}