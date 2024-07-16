namespace TRZ_Console.Models
{
    public class Record
    {
        public string Name = string.Empty;
        public List<string> Workdays = [];

        public Record(string name, List<string> workdays)
        {
            Name = name;
            Workdays = workdays;
        }
    }
}
