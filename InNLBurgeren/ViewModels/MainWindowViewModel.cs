using System;
using Avalonia.Interactivity;
using InNLBurgeren.Views;
using ReactiveUI;

namespace InNLBurgeren.ViewModels;

public class MainWindowViewModel : ReactiveObject
{
    public string Greeting => "Welcome to Avalonia!";
    
    public ReactiveViewModel ReactiveViewModel { get; } = new ReactiveViewModel();
    
    public EventHandler LoginEventHandler { get; set; }
    
    private void Login_OnClick(object? sender, RoutedEventArgs e)
    {
        
        if (true)
        {
            ReactiveUiView ru = new();
            ru.Show();
            //Home home = new Home();
            //home.Show();
        }
        else
        {
            var messageBoxStandardWindow = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Error", "Login information incorrect.");
            messageBoxStandardWindow.Show();
        }
    }
}