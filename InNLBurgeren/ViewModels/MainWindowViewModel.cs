using System;
using System.Reactive;
using Avalonia.Interactivity;
using AvaloniaEdit.Document;
using InNLBurgeren.Views;
using ReactiveUI;

namespace InNLBurgeren.ViewModels;

public class MainWindowViewModel : ViewModelBase
{

    public MainWindowViewModel()
    {
        Login = ReactiveCommand.Create(LoginEventHandler);
    }
    
    public ReactiveCommand<Unit, Unit> Login { get; }
    
    public void LoginEventHandler()
    {
        if (true)
        {
            Home homeView = new();
            homeView.Show();
            var mySql = new DatabaseHandling.MySql();
            mySql.Connect();
        }
        else
        {
            var messageboxStandardWindow = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Error", "Login information incorrect.");
            messageboxStandardWindow.Show();
        }
    }
}