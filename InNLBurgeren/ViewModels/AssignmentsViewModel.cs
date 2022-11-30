using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace InNLBurgeren.ViewModels;


public class AssignmentsViewModel
{
    public ObservableCollection<AssignmentsViewModel> Assignments { get; } = new();
}
