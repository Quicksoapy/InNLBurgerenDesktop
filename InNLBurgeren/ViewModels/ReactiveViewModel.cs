using ReactiveUI;
using System;

namespace InNLBurgeren.ViewModels;

public class ReactiveViewModel : ReactiveObject
{
    public ReactiveViewModel()
    {
        // We can listen to any property changes with "WhenAnyValue" and do whatever we want in "Subscribe".
        this.WhenAnyValue(o => o.Name)
            .Subscribe(o => this.RaisePropertyChanged(nameof(Greeting)));
    }
    
    private string? _Name; // This is our backing field for Name

    public string? Name
    {
        get
        {
            Console.WriteLine($"returned _Name ({_Name})");
            return _Name;
        }
        set
        {
            // We can use "RaiseAndSetIfChanged" to check if the value changed and automatically notify the UI
            Console.WriteLine($"set _Name ({value})");
            this.RaiseAndSetIfChanged(ref _Name, value);
        }
    }
    // Greeting will change based on a Name.
    public string Greeting
    {
        get
        {
            if (string.IsNullOrEmpty(Name))
            {
                // If no Name is provided, use a default Greeting
                Console.WriteLine("returned 'Hello World from Avalonia.Samples'");
                return "Hello World from Avalonia.Samples";
            }
            else
            {
                // else greet the User.
                Console.WriteLine($"returned 'Hello {Name}'");
                return $"Hello {Name}";
            }
        }
    }
}
