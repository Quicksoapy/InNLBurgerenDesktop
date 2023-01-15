using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive;
using System.Reactive.Disposables;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Avalonia.Controls.Chrome;
using HarfBuzzSharp;
using InNLBurgeren.Models;
using InNLBurgeren.Views;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using ReactiveUI;

namespace InNLBurgeren.ViewModels;


public class AssignmentsViewModel : ReactiveObject
{

   public AssignmentsViewModel(DatabaseHandling.MySql.Subjects subjectId)
   {
      OnSubmit = ReactiveCommand.Create(OnSubmitEventHandler);
      SubjectId = subjectId;
   }
   public ReactiveCommand<Unit, Task> OnSubmit { get; }
   private DatabaseHandling.MySql.Subjects SubjectId { get; set; }
   private List<Assignment> AssignmentsList = new List<Assignment>();
   private DatabaseHandling.MySql _mySql = new DatabaseHandling.MySql();
   public int CurrentQuestionId { get; set; } = -1;
   private string currentQuestion;

   public string CurrentQuestion
   {
      get => currentQuestion;
      set => this.RaiseAndSetIfChanged(ref currentQuestion, value);
   }
   public string UserInput { get; set; }

   private async Task OnSubmitEventHandler()
   {
      if (CurrentQuestionId > -1)
      {
         if (UserInput == AssignmentsList[CurrentQuestionId].Answer)
         {
            var messageboxStandardWindow = MessageBox.Avalonia.MessageBoxManager
               .GetMessageBoxStandardWindow("Correct!","");
            await messageboxStandardWindow.Show();
         }
         else
         {
            var messageboxStandardWindow = MessageBox.Avalonia.MessageBoxManager
               .GetMessageBoxStandardWindow("Incorrect.", "");
            await messageboxStandardWindow.Show();
         }
      }
      else
      {
         AssignmentsList = await  _mySql.GetAssignments(SubjectId);
      }
      CurrentQuestionId += 1;
      CurrentQuestion = AssignmentsList[CurrentQuestionId].Question;
   }

}
