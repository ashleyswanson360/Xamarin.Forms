using Xamarin.Forms;

namespace Xamarin.Platform
{
    public interface IEntry : IView
    {
        string Text { get; }
        Color TextColor { get; }
        bool IsPassword { get; }
    }
}