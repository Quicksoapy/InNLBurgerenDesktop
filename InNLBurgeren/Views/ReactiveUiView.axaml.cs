using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace InNLBurgeren.Views;

public partial class ReactiveUiView : Window
{
    public ReactiveUiView()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}