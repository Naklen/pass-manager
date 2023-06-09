using pm.Models;
using pm.Services;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace pm.ViewModels;

public class NewEntryViewModel : ViewModelBase
{
    string? _name;
    string? _pass;
    string? _login;
    public NewEntryViewModel(IDatabaseService dbService) 
    {
        var addEnabled = this.WhenAnyValue(x => x.Name, y => y.Pass, (x, y) => !string.IsNullOrWhiteSpace(x) && !string.IsNullOrWhiteSpace(y));

        Add = ReactiveCommand.Create(() => { dbService.CreatePassEntry(Name, Pass, Login); }, addEnabled);

        Cancel = ReactiveCommand.Create(() => { });
    }

    public string? Name
    {
        get => _name; set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    public string? Pass
    {
        get => _pass; set => this.RaiseAndSetIfChanged(ref _pass, value);
    }

    public string? Login
    {
        get => _login; set => this.RaiseAndSetIfChanged(ref _login, value);
    }

    public ReactiveCommand<Unit, Unit> Add { get; }
    public ReactiveCommand<Unit, Unit> Cancel { get; }
}
