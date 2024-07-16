namespace TRZ_Console.Services
{
    public static class ReadService
    {
        public static string GetInputFileName()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Въведете пълния адрес на екселския файл:");
                Console.ResetColor();
                string? filePath = Console.ReadLine();

                if (filePath != null)
                {
                    if (File.Exists(filePath) && Path.GetExtension(filePath) == ".xlsx")
                    {
                        return filePath;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"'{filePath}' не е валиден екселски файл.");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Опитайте отново.");
                }
            }
        }

        public static void GetSheet1()
        {
            var filePath = GetInputFileName();
            FileInfo file = new FileInfo(filePath);
            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault(x => x.Name.ToLower() == "sheet1")
                    ?? throw new Exception("Липсва worksheet с име \"Sheet1\"");

                ReadSheet1(worksheet);
            }
        }

        public static void ReadSheet1(ExcelWorksheet worksheet)
        {
            for (int row = 1; row <= worksheet.Dimension.End.Row; row++)
            {
                if (worksheet.Cells[row, 1].Value?.ToString() == null)
                    break;
                ReadSheet1Row(worksheet, row);
            }
            ;
        }

        public static void ReadSheet1Row(ExcelWorksheet worksheet, int row)
        {
            string name = worksheet.Cells[row, 1].Value.ToString()!;
            List<string?> workdays = [];

            for (int col = 2; col <= worksheet.Dimension.End.Column; col++)
            {
                workdays.Add(worksheet.Cells[row, col].Value?.ToString());
            }

            name = NameService.CleanName(name);
            Record record = new(name, workdays);
            DataSets.Records.Add(record);
        }
    }
}
