namespace TRZ_Console.Services
{
    public static class WriteService
    {
        public static void WriteErrorSheet(ExcelPackage package)
        {
            var errorWorksheet = package.Workbook.Worksheets.FirstOrDefault(x => x.Name == "ГРЕШКИ");
            if (errorWorksheet == null)
                errorWorksheet = package.Workbook.Worksheets.Add("ГРЕШКИ");
            else
                errorWorksheet.Cells.Clear();

            WriteErrorHeader(errorWorksheet);
            WriteErrors(errorWorksheet);
            errorWorksheet.Cells[errorWorksheet.Dimension.Address].AutoFitColumns();
        }

        static void WriteErrors(ExcelWorksheet worksheet)
        {
            int row = 3;
            foreach (var error in DataSets.Errors)
            {
                WriteErrorRow(worksheet, row, error);
                row++;
            }
        }

        static void WriteErrorRow(ExcelWorksheet worksheet, int row, Error error)
        {
            string errorType;
            switch (error.ErrorType)
            {
                case ErrorType.NotFound:
                    errorType = "Не е намерен";
                    break;

                case ErrorType.NameConflict:
                    errorType = "Конфликт в имената";
                    break;

                case ErrorType.WorkdayConflict:
                    errorType = "Конфликт в работните дни";
                    break;

                default:
                    errorType = "Грешка";
                    break;
            }

            worksheet.Cells[row, 1].Value = errorType;
            worksheet.Cells[row, 2].Value = error.Employee.Name;
            worksheet.Cells[row, 3].Value = string.Join(',', error.Employee.Rows);
            worksheet.Cells[row, 4].Value = error.Description;
        }

        static void WriteErrorHeader(ExcelWorksheet worksheet)
        {
            worksheet.Cells["A1:D1"].Merge = true;
            worksheet.Cells["A1"].Value = "Грешки при обработка";
            worksheet.Cells["A1"].Style.Font.Size = 20;
            worksheet.Cells["A1"].Style.Font.Bold = true;
            worksheet.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

            worksheet.Cells["A2:D2"].Style.Font.Size = 14;
            worksheet.Cells["A2:D2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

            worksheet.Cells["A2"].Value = "Тип";
            worksheet.Cells["B2"].Value = "Име на служител";
            worksheet.Cells["C2"].Value = "Редове";
            worksheet.Cells["D2"].Value = "Описание";
        }

        public static void WriteEmployeeWorkdays(ExcelWorksheet worksheet, int row, List<string?> workdays)
        {
            int col = 3;

            foreach (var workday in workdays)
            {
                if (worksheet.Cells[row, col].Value == null)
                    worksheet.Cells[row, col].Value = workday;
                col++;
            }
        }
    }
}
