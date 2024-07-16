namespace TRZ_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            while (true)
            {
                try
                {
                    // Read Sheet1
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
