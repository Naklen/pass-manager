using pm.Services;

namespace pm.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel(ArrayDatabaseService dbService)
    {
        List = new PassListViewModel(dbService);
    }
    public PassListViewModel List { get; }
}
