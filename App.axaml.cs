using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using pm.Services;
using pm.ViewModels;
using pm.Views;

namespace pm;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var dbService = new ArrayDatabaseService();
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(dbService),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}