using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using InNLBurgeren.Models;

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
        List<Assignment> assignments = new List<Assignment>();
        
        //load DB
        //Foreach (item in DB) {assignments.Add(item);
        Assignment sample = new Assignment(1, "test", 3, 45);
        Assignment sample2 = new Assignment(2, "test2", 3, 45);

        assignments.Add(sample);
        assignments.Add(sample2);
        AssignmentsListBox.SetValue(sample, );
    }
}