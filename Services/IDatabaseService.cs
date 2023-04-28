using pm.Models;
using System.Collections.Generic;

namespace pm.Services
{
    public interface IDatabaseService
    {
        IEnumerable<PassEntryId> GetPassEntryIds();
        PassEntry? GetPassEntry(int id);
        void CreatePassEntry(string name, string pass, string login);
        void CreatePassEntry(string name, string pass);
        void DeletePassEntry(int id);
        void DeleteAllPassEntries();
        void EditPassEntry(int id, string? name, string? pass, string? login);
    }
}
