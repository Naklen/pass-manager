using pm.Models;
using pm.Services;
using ReactiveUI;
using System.Drawing;
using System.Reactive.Linq;

namespace pm.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    ViewModelBase _content;
    public MainWindowViewModel(ArrayDatabaseService dbService)
    {
        Content = List = new PassListViewModel(dbService);
    }
    public ViewModelBase Content
    {
        get => _content;
        private set => this.RaiseAndSetIfChanged(ref _content, value);
    }

    public PassListViewModel List { get; }

    public void AddNewEntry()
    {
        var vm = new NewEntryViewModel();

        Observable.Merge(vm.Cancel).Take(1).Subscribe(() => { Content = List; });

        Content = vm;        
    }
}
