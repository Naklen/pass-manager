using DynamicData.Binding;
using pm.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pm.ViewModels
{
    public class PassListViewModel : ViewModelBase
    {
        public PassListViewModel(IEnumerable<PassEntry> entries)
        {
            Entries = new ObservableCollection<PassEntry>(entries);
            ExpandedId = -1;
        }

        public ObservableCollection<PassEntry> Entries { get; }
        public int ExpandedId { get; set; }
    }
}
