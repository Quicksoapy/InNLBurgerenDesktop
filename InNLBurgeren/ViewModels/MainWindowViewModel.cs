using ReactiveUI;

namespace InNLBurgeren.ViewModels;

public class MainWindowViewModel : ReactiveObject
{
    public string Greeting => "Welcome to Avalonia!";
    
    public ReactiveViewModel ReactiveViewModel { get; } = new ReactiveViewModel();
}