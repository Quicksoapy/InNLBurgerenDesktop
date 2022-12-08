using System;
using Avalonia.Interactivity;
using AvaloniaEdit.Document;
using InNLBurgeren.Views;
using ReactiveUI;

namespace InNLBurgeren.ViewModels;

public class MainWindowViewModel : ReactiveObject
{
    public string Greeting => "Welcome to Avalonia!";

    public ReactiveViewModel ReactiveViewModel { get; } = new ReactiveViewModel();

    public void LoginEventHandler()
    {
        if (true)
        {
            ReactiveUiView ru = new();
            ru.Show();
        }
        else
        {
            var messageboxStandardWindow = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Error", "Login information incorrect.");
            messageboxStandardWindow.Show();
        }
    }
}