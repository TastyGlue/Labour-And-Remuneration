namespace TRZ_Console
{
    public static class DataSets
    {
        public static List<Record> Records { get; set; } = [];
        public static List<Employee> Employees { get; set; } = [];
        public static List<Error> Errors { get; set; } = [];

        public static void ClearData()
        {
            Records.Clear();
            Employees.Clear();
            Errors.Clear();
        }
    }
}
