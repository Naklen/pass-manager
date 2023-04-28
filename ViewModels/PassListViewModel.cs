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
using pm.Services;

namespace pm.ViewModels
{
    public class PassListViewModel : ViewModelBase
    {
        readonly IDatabaseService _dbServise;
        string? _expandedPass;
        public string? ExpandedPass { get => _expandedPass; set => this.RaiseAndSetIfChanged(ref _expandedPass, value); }
        string? _expandedLogin;
        public string? ExpandedLogin { get => _expandedLogin; set => this.RaiseAndSetIfChanged(ref _expandedLogin, value); }
        public 
        int _expandedId;
        public PassListViewModel(IDatabaseService databaseService)
        {
            _dbServise = databaseService;
            Entries = new ObservableCollection<PassEntryId>(_dbServise.GetPassEntryIds());
            _expandedId = -1;
            ExpandOrCollapseEntry = ReactiveCommand.Create<int>(SetExpandedEntry);
        }

        public ObservableCollection<PassEntryId> Entries { get; }
        public int ExpandedId { get => _expandedId; set => this.RaiseAndSetIfChanged(ref _expandedId, value); }
        public ReactiveCommand<int, Unit> ExpandOrCollapseEntry { get; }

        void SetExpandedEntry(int id)
        {
            if (ExpandedId == id)
            {
                ExpandedId = -1;
                ExpandedLogin = null;
                ExpandedPass = null;
            }
            else
            {
                ExpandedId = id;
                var entry = _dbServise.GetPassEntry(id);
                ExpandedPass = entry.Pass;
                ExpandedLogin = entry.Login;
            }
        }

        public async void CopyToClipboard(string text) {
            await ClipboardService.SetTextAsync(text);
        }

        public void CopyPassToClipboard(int id)
        {
            CopyToClipboard(_dbServise.GetPassEntry(id).Pass);
        }
    }
}
