namespace TRZ_Console.Models
{
    public class Employee
    {
        public string Name { get; set; } = string.Empty;
        public bool IsTwoNames { get; set; }
        public List<string?> Workdays { get; set; } = [];
        public List<int> Rows { get; set; } = [];
        public string? Store { get; set; }
        public int? StoreRow { get; set; }

        public Employee(string name, bool isTwoNames, List<string?> workdays, List<int> rows)
        {
            Name = name;
            IsTwoNames = isTwoNames;
            Workdays = workdays;
            Rows = rows;
        }

        public override string ToString()
        {
            return $"{Name} - Rows: {string.Join(" ", Rows)}";
        }
    }
}
