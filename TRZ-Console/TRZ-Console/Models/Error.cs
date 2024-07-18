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
            if (this.ErrorType == ErrorType.NotFound)
            {
                return "Този служител не беше намерен в нито един магазин";
            }
            else if (this.ErrorType == ErrorType.Conflict)
            {
                string description = "Има конфликт с имената на този служител в";

                foreach (var kvp in foundIn)
                {
                    description += $" [Магазин: {kvp.Key}, Ред: {kvp.Value}]";
                }

                return description;
            }
            else
                return string.Empty;
        }
    }

    public enum ErrorType
    {
        NotFound,
        Conflict
    }
}
