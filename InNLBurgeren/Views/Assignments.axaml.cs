using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using InNLBurgeren.Models;
using InNLBurgeren.ViewModels;

namespace InNLBurgeren.Views;

public partial class Assignments : Window
{
    public Assignments()
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