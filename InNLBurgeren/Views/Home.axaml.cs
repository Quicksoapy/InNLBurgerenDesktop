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
        Assignments assignments = new Assignments();
        assignments.Show();
    }

    private void Thema2_OnClick(object? sender, PointerReleasedEventArgs e)
    {
        Assignments assignments = new Assignments();
        assignments.Show();

    }
    
    private void Thema3_OnClick(object? sender, PointerReleasedEventArgs e)
    {
        Assignments assignments = new Assignments();
        assignments.Show();

    }
    
    private void Thema4_OnClick(object? sender, PointerReleasedEventArgs e)
    {
        Assignments assignments = new Assignments();
        assignments.Show();

    }
}