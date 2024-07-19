namespace TRZ_Console.Models
{
    public class Error
    {
        public Error(ErrorType errorType, Employee employee, Dictionary<string, int> foundIn)
        {
            ErrorType = errorType;
            Employee = employee;
            Description = CreateDescription(foundIn);
        }

        public ErrorType ErrorType { get; set; }
        public Employee Employee { get; set; }
        public string Description { get; set; }

        private string CreateDescription(Dictionary<string, int> foundIn)
        {
            if (ErrorType == ErrorType.NotFound)
            {
                return "Този служител не беше намерен в нито един магазин";
            }
            else if (ErrorType == ErrorType.NameConflict)
            {
                string description = "Има конфликт с имената на този служител в";

                foreach (var kvp in foundIn)
                {
                    description += $" [Магазин: {kvp.Key}, Ред: {kvp.Value}]";
                }

                return description;
            }
            else if (ErrorType == ErrorType.WorkdayConflict)
            {
                string description = "Има конфликт при работните дни на този служител за ";
                description += $"[Ден: {foundIn.First().Value}]. ";

                description += $"Конфликтни стойности [{foundIn.First().Key} и {foundIn.Skip(1).First().Key}]";

                return description;
            }
            else
                return string.Empty;
        }
    }

    public enum ErrorType
    {
        NotFound,
        NameConflict,
        WorkdayConflict
    }
}
