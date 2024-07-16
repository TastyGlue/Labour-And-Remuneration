using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRZ_Console.Models
{
    public class Employee
    {
        public string Name = string.Empty;
        public bool IsTwoNames;
        public List<string> Workdays = [];
        public bool IsNameConflict;
        public Dictionary<string, string> Conflict = [];

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
