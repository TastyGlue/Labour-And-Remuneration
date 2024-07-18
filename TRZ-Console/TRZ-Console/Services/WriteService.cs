namespace TRZ_Console.Services
{
    public static class WriteService
    {
        public static void WriteReportSheet(ExcelPackage package)
        {
            ExcelWorksheet reportWorksheet = package.Workbook.Worksheets.Add("Отчет");
        }

        public static void WriteEmployeeWorkdays(ExcelWorksheet worksheet, int row, List<string?> workdays)
        {
            int col = 3;

            foreach (var workday in workdays)
            {
                worksheet.Cells[row, col++].Value = workday;
            }
        }
    }
}
