using System;
using System.Reactive;
using System.Security.Cryptography;
using System.Text;
using Avalonia.Interactivity;
using AvaloniaEdit.Document;
using InNLBurgeren.Models;
using InNLBurgeren.Views;
using ReactiveUI;
using MySql = InNLBurgeren.DatabaseHandling.MySql;

namespace InNLBurgeren.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        Login = ReactiveCommand.Create(LoginEventHandler);
        Register = ReactiveCommand.Create(RegisterEventHandler);
        
        KnmOpen = ReactiveCommand.Create(KnmEventHandler);
        ReadingOpen = ReactiveCommand.Create(ReadingEventHandler);
        ListeningOpen = ReactiveCommand.Create(ListeningEventHandler);
        SpeakingOpen = ReactiveCommand.Create(SpeakingEventHandler);
        WritingOpen = ReactiveCommand.Create(WritingEventHandler);
    }
    
    public ReactiveCommand<Unit, Unit> Login { get; }
    public ReactiveCommand<Unit, Unit> Register { get; }
    public ReactiveCommand<Unit, Unit> KnmOpen { get; }
    public ReactiveCommand<Unit, Unit> ReadingOpen { get; }
    public ReactiveCommand<Unit, Unit> ListeningOpen { get; }
    public ReactiveCommand<Unit, Unit> SpeakingOpen { get; }
    public ReactiveCommand<Unit, Unit> WritingOpen { get; }

    private DatabaseHandling.MySql _mySql = new DatabaseHandling.MySql();
    public string Username { get; set; }
    public string Password { get; set; }
    public string UsernameRegister { get; set; }
    public string PasswordRegister { get; set; }

    private void LoginEventHandler()
    {
        //_mySql.InitializeDatabase();
        string hashedPassword;
        using (SHA512 shaM = new SHA512Managed())
        {
            byte[] bytes = Encoding.ASCII.GetBytes(Password);
            hashedPassword = Encoding.ASCII.GetString(shaM.ComputeHash(bytes));
        }
        if (_mySql.CheckLogin(Username, hashedPassword).Result)
        {
            HomeView homeView = new()
            {
                DataContext = this,
                Title = Username
            };
            homeView.Show();
        }
        else
        {
            var messageboxStandardWindow = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Error", "Login information incorrect.");
            messageboxStandardWindow.Show();
        }
    }

    private void RegisterEventHandler()
    {
        //_mySql.InitializeDatabase();
        string hashedPassword;
        using (SHA512 shaM = new SHA512Managed())
        {
            byte[] bytes = Encoding.ASCII.GetBytes(PasswordRegister);
            hashedPassword = Encoding.ASCII.GetString(shaM.ComputeHash(bytes));
        }

        if (_mySql.CheckRegister(UsernameRegister).Result)
        {
            var messageboxUsernameError = MessageBox.Avalonia.MessageBoxManager
                .GetMessageBoxStandardWindow("Error", "Username already in use.");
            messageboxUsernameError.Show();
            return;
        }

        _mySql.RegisterAccount(UsernameRegister, hashedPassword);
        var messageboxAccountCreation = MessageBox.Avalonia.MessageBoxManager
            .GetMessageBoxStandardWindow("Success", "Account " + UsernameRegister + " created.");
        messageboxAccountCreation.Show();
    }

    private void KnmEventHandler()
    {
        Assignments assignments = new()
        {
            DataContext = new AssignmentsViewModel()
        };
        assignments.Show();
    }

    private void ReadingEventHandler()
    {
        Assignments assignments = new()
        {
            DataContext = new AssignmentsViewModel()
        };
        assignments.Show();
    }

    private void ListeningEventHandler()
    {
        Assignments assignments = new()
        {
            DataContext = new AssignmentsViewModel()
        };
        assignments.Show();
    }

    private void SpeakingEventHandler()
    {
        Assignments assignments = new()
        {
            DataContext = new AssignmentsViewModel()
        };
        assignments.Show();
    }

    private void WritingEventHandler()
    {
        Assignments assignments = new()
        {
            DataContext = new AssignmentsViewModel()
        };
        assignments.Show();
    }
}