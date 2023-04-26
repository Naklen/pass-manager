using pm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pm.Services
{
    public class ArrayDatabase
    {
        List<PassEntry> db;

        public ArrayDatabase()
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
    }
}
