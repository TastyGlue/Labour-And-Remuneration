namespace TRZ_Console.Models
{
    public class Record
    {
        public string Name { get; set; } = string.Empty;
        public List<string?> Workdays { get; set; } = [];

        public Record(string name, List<string?> workdays)
        {
            Name = name;
            Workdays = workdays;
        }
    }
}
