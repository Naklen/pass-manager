using DynamicData.Binding;
using pm.Models;
using ReactiveUI;
using TextCopy;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace pm.ViewModels
{
    public class PassListViewModel : ViewModelBase
    {
        int _expandedId;
        public PassListViewModel(IEnumerable<PassEntry> entries)
        {
            Entries = new ObservableCollection<PassEntry>(entries);
            _expandedId = -1;
            ExpandOrCollapseEntry = ReactiveCommand.Create<int>(SetExpandedId);
        }

        public ObservableCollection<PassEntry> Entries { get; }
        public int ExpandedId { get => _expandedId; set => this.RaiseAndSetIfChanged(ref _expandedId, value); }
        public ReactiveCommand<int, Unit> ExpandOrCollapseEntry { get; }

        void SetExpandedId(int id)
        {
            ExpandedId = ExpandedId == id ? -1 : id;
        }

        public async void CopyToClipboard(string text) {
            await ClipboardService.SetTextAsync(text);
        }
    }
}
