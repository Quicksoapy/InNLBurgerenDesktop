using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using InNLBurgeren.ViewModels;

namespace InNLBurgeren.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
    
    
}