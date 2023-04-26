using pm.Services;

namespace pm.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel(ArrayDatabase db)
    {
        List = new PassListViewModel(db.GetAll());
    }
    public PassListViewModel List { get; }
}
