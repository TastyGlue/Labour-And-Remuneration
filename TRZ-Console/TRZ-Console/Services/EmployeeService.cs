namespace TRZ_Console.Services
{
    public static class EmployeeService
    {
        public static void SearchStores(ExcelPackage package)
        {
            GetEmployees();

            List<ExcelWorksheet> worksheets = package.Workbook.Worksheets.Where(x => x.Name.ToLower() != "sheet1").ToList();

            foreach (Employee employee in DataSets.Employees)
            {
                Dictionary<string, int> foundIn = [];

                try
                {
                    foreach (ExcelWorksheet worksheet in worksheets)
                    {
                        int startRow = 11;

                        for (int row = startRow; row <= worksheet.Dimension.End.Row; row++)
                        {
                            if (!int.TryParse(worksheet.Cells[row, 1].Value?.ToString(), out int num))
                                continue;

                            string? nameInStore = worksheet.Cells[row, 2].Value?.ToString();
                            if (NameService.IsNamesMatching(nameInStore, employee))
                                foundIn.Add(worksheet.Name, row);
                        }
                    }
                }
                catch (ArgumentException)
                {
                    Error error = new(ErrorType.NameDuplication, employee, foundIn);
                    DataSets.Errors.Add(error);
                    break;
                }

                if (foundIn.Count == 1)
                {
                    employee.Store = foundIn.First().Key;
                    employee.StoreRow = foundIn.First().Value;
                    WriteService.WriteEmployeeWorkdays(
                        package.Workbook.Worksheets.First(x => x.Name == employee.Store), 
                        (int)employee.StoreRow, 
                        employee.Workdays);
                }
                else
                {
                    Error error = new(foundIn.Count == 0 ? ErrorType.NotFound : ErrorType.NameConflict,
                        employee,
                        foundIn);
                    DataSets.Errors.Add(error);
                }
            }
        }

        static void GetEmployees()
        {
            var employeeGroups = DataSets.Records.GroupBy(x => x.Name, StringComparer.OrdinalIgnoreCase);

            foreach (var group in employeeGroups)
            {
                string name = group.Key;
                bool isTwoNames = name.Split(' ').Length == 2;
                var workdays = GetWorkDays(group, out var workdaysError);
                List<int> rows = group.Select(x => x.Row).ToList();

                Employee employee = new(name, isTwoNames, workdays, rows);
                if (workdaysError == null)
                    DataSets.Employees.Add(employee);
                else
                {
                    Error error = new(ErrorType.WorkdayConflict, employee, workdaysError);
                    DataSets.Errors.Add(error);
                }
            }
        }

        static List<string?> GetWorkDays(IGrouping<string, Record> group, out Dictionary<string, int>? workdaysError)
        {
            workdaysError = null;
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

                    if (workdays[index] != null && workday != null && !workday.Equals(workdays[index], StringComparison.OrdinalIgnoreCase))
                    {
                        workdaysError = new Dictionary<string, int>
                        {
                            { workdays[index]!, index + 1 },
                            { workday, index + 1 }
                        };
                        return [];
                    }

                    workdays[index] = workday;
                    index++;
                }
            }

            return workdays.ToList();
        }
    }
}
