namespace TRZ_Console.Services
{
    public static class NameService
    {
        public static readonly string[] Separators = { "-от", "- от", " - от", " -от", " от ", "-тел:", " -тел:", " - тел:", "- тел:", " - ", " -", "- ", ",", ":", "/", ".-" };

        public static string CleanName(string name)
        {
            List<int> indexes = [];
            foreach(var separator in Separators)
            {
                int index = name.IndexOf(separator, StringComparison.OrdinalIgnoreCase);
                if (index != -1)
                {
                    indexes.Add(index);
                }
            }

            string pattern = @"-\d";
            Match match = Regex.Match(name, pattern);
            if (match.Success)
                indexes.Add(match.Index);

            name = name.TrimEnd();

            if (indexes.Count == 0)
            {
                return name;
            }
            else
            {
                int firstIndex = indexes.Min();
                return name.Substring(0, firstIndex);
            }
        }
    }
}
