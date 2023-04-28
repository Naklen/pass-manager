namespace pm.Models
{
    public class PassEntryId
    {
        public int Id { get; }
        public string Name { get; set; }

        public PassEntryId(int id, string name)
        {
            Id = id;
            Name = name;            
        }
    }
}
