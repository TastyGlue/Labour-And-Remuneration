namespace TRZ_Console.Models
{
    public class Record
    {
        public int Row { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<string?> Workdays { get; set; } = [];

        public Record(int row, string name, List<string?> workdays)
        {
            Row = row;
            Name = name;
            Workdays = workdays;
        }
    }
}
