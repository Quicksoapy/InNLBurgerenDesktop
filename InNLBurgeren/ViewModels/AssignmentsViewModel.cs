using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive;
using System.Runtime.CompilerServices;
using InNLBurgeren.Models;
using ReactiveUI;

namespace InNLBurgeren.ViewModels;


public class AssignmentsViewModel  : ReactiveObject
{
   public AssignmentsViewModel()
   {
      OnSubmit = ReactiveCommand.Create(OnSubmitEventHandler);
   }
   public ReactiveCommand<Unit, Unit> OnSubmit { get; }

   public void OnSubmitEventHandler()
   {
      
   }
}
