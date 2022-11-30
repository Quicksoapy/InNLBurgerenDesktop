using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace InNLBurgeren.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private void Login_OnClick(object? sender, RoutedEventArgs e)
    {

        if (true)
        {
            Home home = new Home();
            home.Show();
        }
        else
        {
            var messageBoxStandardWindow = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Error", "Login information incorrect.");
            messageBoxStandardWindow.Show();
        }
    }
}