namespace UserApi.Models
{
    public class UserItem
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Archetype { get; set; }
        public int Age { get; set; }
        public string Status {get;set;}
        public string Location { get; set; }
        public decimal Income { get; set; }
        public string Headshot { get; set; }
    }
}