namespace TRZ_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            while (true)
            {
                try
                {
                    var filePath = ReadService.GetInputFileName();
                    FileInfo file = new FileInfo(filePath);
                    using (ExcelPackage package = new ExcelPackage(file))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault(x => x.Name.ToLower() == "sheet1")
                            ?? throw new Exception("Липсва worksheet с име \"Sheet1\"");

                        ReadService.ReadSheet1(worksheet);
                        EmployeeService.SearchStores(package);
                        WriteService.WriteErrorSheet(package);

                        File.WriteAllBytes(filePath, package.GetAsByteArray());
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Вашият обработен екселски файл е готов.");
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Нещо се обърка.");
                    Console.WriteLine($"Грешка: '{ex.Message}'");
                }

                bool isEnd = ReadService.UserInputMainLoop();
                if (isEnd)
                    break;
                else
                    DataSets.ClearData();
            }
        }
    }
}
