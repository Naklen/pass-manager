using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace pm.ViewModels;

public class NewEntryViewModel : ViewModelBase
{
    public NewEntryViewModel() 
    {
        Cancel = ReactiveCommand.Create(() => { });
    }
    public ReactiveCommand<Unit, Unit> Cancel { get; }
}
