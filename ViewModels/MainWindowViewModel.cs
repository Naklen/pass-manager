using pm.Models;
using pm.Services;
using ReactiveUI;
using System;
using System.Drawing;
using System.Reactive.Linq;

namespace pm.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    ViewModelBase _content;
    IDatabaseService _dbService;
    public MainWindowViewModel(IDatabaseService dbService)
    {
        _dbService = dbService;
        Content = List = new PassListViewModel(_dbService);
    }
    public ViewModelBase Content
    {
        get => _content;
        private set => this.RaiseAndSetIfChanged(ref _content, value);
    }

    public PassListViewModel List { get; }

    public void AddNewEntry()
    {
        var vm = new NewEntryViewModel(_dbService);

        Observable.Merge(vm.Add, vm.Cancel).Take(1).Subscribe(_ => { List.UpdateEntriesList(); Content = List; });        

        Content = vm;        
    }
}
