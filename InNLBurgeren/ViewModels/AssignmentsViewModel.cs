using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive;
using System.Reactive.Disposables;
using System.Runtime.CompilerServices;
using Avalonia.Controls.Chrome;
using HarfBuzzSharp;
using InNLBurgeren.Models;
using InNLBurgeren.Views;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using ReactiveUI;

namespace InNLBurgeren.ViewModels;


public class AssignmentsViewModel : ReactiveObject
{

   public AssignmentsViewModel()
   {
      OnLoad = ReactiveCommand.Create(OnLoadEventHandler);
      OnSubmit = ReactiveCommand.Create(OnSubmitEventHandler);
   }
   public ReactiveCommand<Unit, Unit> OnLoad { get; }
   public ReactiveCommand<Unit, Unit> OnSubmit { get; }

   private List<Assignment> AssignmentsList = new List<Assignment>();

   public int CurrentQuestionId { get; set; } = -1;
   private string currentQuestion;

   public string CurrentQuestion
   {
      get => currentQuestion;
      set => this.RaiseAndSetIfChanged(ref currentQuestion, value);
   }
   public string UserInput { get; set; }
   
   private void OnLoadEventHandler()
   {
      
   }

   private void OnSubmitEventHandler()
   {
      if (CurrentQuestionId > -1)
      {
         if (UserInput == AssignmentsList[CurrentQuestionId].Answer)
         {
            var messageboxStandardWindow = MessageBox.Avalonia.MessageBoxManager
               .GetMessageBoxStandardWindow("Correct!","");
            messageboxStandardWindow.Show();
         }
         else
         {
            var messageboxStandardWindow = MessageBox.Avalonia.MessageBoxManager
               .GetMessageBoxStandardWindow("Incorrect.", "");
            messageboxStandardWindow.Show();
         }
      }
      else
      {
         AssignmentsList.Add(new Assignment(1, "1+1", 1, "2"));
         AssignmentsList.Add(new Assignment(2, "5-2", 1, "3"));
         AssignmentsList.Add(new Assignment(3, "4*4", 1, "16"));
      }
      CurrentQuestionId += 1;
      CurrentQuestion = AssignmentsList[CurrentQuestionId].Question;
   }

}
