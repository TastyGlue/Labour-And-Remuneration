namespace TRZ_Console.Services
{
    public static class EmployeeService
    {
        public static void GetEmployees()
        {
            var employeeGroups = DataSets.Records.GroupBy(x => x.Name, StringComparer.OrdinalIgnoreCase);

            foreach (var group in employeeGroups)
            {
                string name = group.Key;
                bool isTwoNames = name.Split(' ').Length == 2;
                var workdays = GetWorkDays(group);
                List<int> rows = group.Select(x => x.Row).ToList();

                Employee employee = new(name, isTwoNames, workdays, rows);
                DataSets.Employees.Add(employee);
            }
        }

        static List<string?> GetWorkDays(IGrouping<string, Record> group)
        {
            string?[] workdays = new string?[31];
            int index;

            foreach (var record in group)
            {
                index = 0;
                foreach (var workday in record.Workdays)
                {
                    if (index > 30)
                        break;

                    if (workdays[index] != null && workday == null)
                    {
                        index++;
                        continue;
                    }

                    workdays[index] = workday;
                    index++;
                }
            }

            return workdays.ToList();
        }
    }
}
