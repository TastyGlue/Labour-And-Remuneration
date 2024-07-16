namespace TRZ_Console.Models
{
    public class Employee
    {
        public string Name { get; set; } = string.Empty;
        public bool IsTwoNames { get; set; }
        public List<string> Workdays { get; set; } = [];
        public bool IsNameConflict { get; set; }
        public Dictionary<string, string> Conflict { get; set; } = [];

        public Employee(string name, bool isTwoNames, List<string> workdays, bool isNameConflict, Dictionary<string, string> conflict)
        {
            Name = name;
            IsTwoNames = isTwoNames;
            Workdays = workdays;
            IsNameConflict = isNameConflict;
            Conflict = conflict;
        }
    }
}
