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
                    // Read Sheet1
                    ReadService.GetSheet1();
                    // Write data to other sheets
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Вашият обработен екселски файл е готов.");
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Нещо се обърка.");
                    Console.WriteLine($"Грешка: '{ex.Message}'");
                }

                // Read user input
                //Clear data sets
            }
        }
    }
}
