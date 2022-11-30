using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;

namespace InNLBurgeren.Views;

public partial class Home : Window
{
    public Home()
    {
        InitializeComponent();
        //UsernameLabel.Content = usernameText;
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
        
    }

    private void Thema1_OnClick(object? sender, PointerReleasedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void Thema2_OnClick(object? sender, PointerReleasedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
    
    private void Thema3_OnClick(object? sender, PointerReleasedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
    
    private void Thema4_OnClick(object? sender, PointerReleasedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}