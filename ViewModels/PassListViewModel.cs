using pm.Models;
using pm.Services;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using TextCopy;

namespace pm.ViewModels
{
    public class PassListViewModel : ViewModelBase
    {
        readonly IDatabaseService _dbServise;
        string? _expandedPass;
        public string? ExpandedPass { get => _expandedPass; set => this.RaiseAndSetIfChanged(ref _expandedPass, value); }
        string? _expandedName;
        public string? ExpandedName { get => _expandedName; set => this.RaiseAndSetIfChanged(ref _expandedName, value); }
        string? _expandedLogin;
        public string? ExpandedLogin { get => _expandedLogin; set => this.RaiseAndSetIfChanged(ref _expandedLogin, value); }
        int _expandedId;
        public int ExpandedId { get => _expandedId; set => this.RaiseAndSetIfChanged(ref _expandedId, value); }
        bool _isEditing;
        public bool IsEditing { get => _isEditing; set => this.RaiseAndSetIfChanged(ref _isEditing, value); }

        public PassListViewModel(IDatabaseService databaseService)
        {
            _dbServise = databaseService;
            Entries = new ObservableCollection<PassEntryId>(_dbServise.GetPassEntryIds());
            _expandedId = -1;
            ExpandOrCollapseEntry = ReactiveCommand.Create<int>(SetExpandedEntry);
            CopyPassToClipboard = ReactiveCommand.Create<int>(async id => { await CopyToClipboard(_dbServise.GetPassEntry(id).Pass); });
            _isEditing = false;
        }

        public ObservableCollection<PassEntryId> Entries { get; private set; }

        public ReactiveCommand<int, Unit> ExpandOrCollapseEntry { get; }
        public ReactiveCommand<int, Unit> CopyPassToClipboard { get; }

        void SetExpandedEntry(int id)
        {
            if (ExpandedId == id)
            {
                ExpandedId = -1;
                ExpandedLogin = null;
                ExpandedPass = null;
                ExpandedName = null;
            }
            else
            {
                ExpandedId = id;
                var entry = _dbServise.GetPassEntry(id);
                ExpandedPass = entry?.Pass;
                ExpandedName = entry?.Name;
                ExpandedLogin = entry?.Login;
            }
            IsEditing = false;
        }

        public void SwichEditingMode()
        {
            IsEditing = !IsEditing;
        }

        public void UpdateEntriesList()
        {
            Entries = new ObservableCollection<PassEntryId>(_dbServise.GetPassEntryIds());
        }

        public static async Task CopyToClipboard(string text)
        {
            await ClipboardService.SetTextAsync(text);
        }

        public void DeleteEntry(int id)
        {
            _dbServise.DeletePassEntry(id);
            Entries.Remove(Entries.First(e => e.Id == id));
            ExpandedId = -1;
        }

        public void EditEntry()
        {
            if (_dbServise.GetPassEntry(ExpandedId) is PassEntry editingEntry && ExpandedPass != "" && ExpandedName != "")
            {
                var newPass = editingEntry.Pass != ExpandedPass ? ExpandedPass : null;
                var newName = editingEntry.Name != ExpandedName ? ExpandedName : null;
                var newLogin = editingEntry.Login == ExpandedLogin || ExpandedLogin == "" ? null : ExpandedLogin;
                _dbServise.EditPassEntry(ExpandedId, newName, newPass, newLogin);
                if (newName is not null)
                    Entries.First(e => e.Id != ExpandedId).Name = newName;
                SwichEditingMode();
            }
        }

        public void CancelEditing()
        {
            if (_dbServise.GetPassEntry(ExpandedId) is PassEntry editingEntry)
            {
                ExpandedLogin = editingEntry.Login;
                ExpandedName = editingEntry.Name;
                ExpandedPass = editingEntry.Pass;
            }
            SwichEditingMode();
        }
    }
}
