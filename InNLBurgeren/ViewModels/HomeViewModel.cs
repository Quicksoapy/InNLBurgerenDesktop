using System.Collections.Generic;
using System.Reactive;
using InNLBurgeren.Views;
using ReactiveUI;

namespace InNLBurgeren.ViewModels;

public class HomeViewModel : ReactiveObject
{
    public HomeViewModel()
    {
        KnmOpen = ReactiveCommand.Create(KnmEventHandler);
        ReadingOpen = ReactiveCommand.Create(ReadingEventHandler);
        ListeningOpen = ReactiveCommand.Create(ListeningEventHandler);
        SpeakingOpen = ReactiveCommand.Create(SpeakingEventHandler);
        WritingOpen = ReactiveCommand.Create(WritingEventHandler);
    }
    public ReactiveCommand<Unit, Unit> KnmOpen { get; }
    public ReactiveCommand<Unit, Unit> ReadingOpen { get; }
    public ReactiveCommand<Unit, Unit> ListeningOpen { get; }
    public ReactiveCommand<Unit, Unit> SpeakingOpen { get; }
    public ReactiveCommand<Unit, Unit> WritingOpen { get; }

    
    public void KnmEventHandler()
    {
        Assignments assignments = new()
        {
            
        };
        assignments.Show();
    }
    public void ReadingEventHandler()
    {
        Assignments assignments = new();
        assignments.Show();
    }
    public void ListeningEventHandler()
    {
        Assignments assignments = new();
        assignments.Show();
    }
    public void SpeakingEventHandler()
    {
        Assignments assignments = new();
        assignments.Show();
    }
    public void WritingEventHandler()
    {
        Assignments assignments = new();
        assignments.Show();
    }
}