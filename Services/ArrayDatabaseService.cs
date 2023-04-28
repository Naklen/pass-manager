using pm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pm.Services
{
    public class ArrayDatabaseService : IDatabaseService
    {
        readonly List<PassEntry> db;

        public ArrayDatabaseService()
        {
            db = new List<PassEntry>()
            {
                new PassEntry(0, "vk", "1234"),
                new PassEntry(1, "steam", "pass", "login"),
                new PassEntry(2, "GitHub", "Password", "GitName"),
                new PassEntry(3, "microsoft", "qwerty"),
                new PassEntry(4, "gmail", "111111", "hi.ksta@gmail.com")
            };
        }

        public PassEntry[] GetAll() => db.ToArray();

        public PassEntry[] AddEntry(string name, string pass, string? login)
        {
            var newEntryId = db.Last().Id + 1;
            var newEntry = login == null ? new PassEntry(newEntryId, name, pass) : new PassEntry(newEntryId, name, pass, login);
            db.Add(newEntry);
            return db.ToArray();
        }

        public PassEntry[] ChangeEntry(int id, PassEntry newEntry) 
        {
            var entry = db.Find(e => e.Id == id);
            if (entry != null)
            {
                entry.Name = newEntry.Name;
                entry.Pass = newEntry.Pass;
                entry.Login = newEntry.Login;
            }
            return db.ToArray();
        }

        public PassEntry[] RemoveEntry(int id) 
        {
            db.RemoveAll(e => e.Id == id);
            return db.ToArray();
        }

        //--------------------

        public IEnumerable<PassEntryId> GetPassEntryIds()
        {
            return db.Select(e => new PassEntryId(e.Id, e.Name));
        }

        public PassEntry? GetPassEntry(int id)
        {
            return db.Find(e => e.Id == id);
        }

        public void CreatePassEntry(string name, string pass, string? login)
        {
            var newEntryId = db.Max(e => e.Id) + 1;
            var newEntry = login == null ? new PassEntry(newEntryId, name, pass) : new PassEntry(newEntryId, name, pass, login);
            db.Add(newEntry);            
        }

        public void CreatePassEntry(string name, string pass)
        {
            CreatePassEntry(name, pass, null);
        }

        public void DeletePassEntry(int id)
        {
            db.RemoveAll(e => e.Id == id);
        }

        public void DeleteAllPassEntries()
        {
            db.Clear();
        }

        public void EditPassEntry(int id, string? name, string? pass, string? login)
        {            
            if (db.Find(e => e.Id == id) is PassEntry entry)
            {
                if (name is not null)
                    entry.Name = name;
                if (pass is not null) 
                    entry.Pass = pass;
                if (login is not null)
                    entry.Login = login;                
            }
        }
    }
}
