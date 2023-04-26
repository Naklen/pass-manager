namespace pm.Models
{
    public class PassEntry
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Pass { get; set; }
        public string? Login { get; set; }

        public PassEntry(int id, string name, string pass, string login) 
        { 
            Id = id;
            Name = name;
            Pass = pass;
            Login = login;
        }

        public PassEntry(int id, string name, string pass) 
        {
            Id = id;
            Name = name;
            Pass = pass;
        }
    }
}
