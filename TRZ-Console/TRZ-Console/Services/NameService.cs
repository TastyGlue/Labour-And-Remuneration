namespace TRZ_Console.Services
{
    public static class NameService
    {
        public static string CleanName(string name)
        {
            string[] words = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            List<string> names = [];

            for (int i = 0; i < words.Length; i++)
            {
                if (i == 3)
                    break;

                names.Add(words[i]);
            }

            string lastName = names[^1];
            int symbolIndex = FindFirstNonAlphabeticalSymbol(lastName);

            if (symbolIndex != -1)
            {
                lastName = lastName.Substring(0, symbolIndex);
                names[^1] = lastName;
            }

            return string.Join(' ', names);
        }

        static int FindFirstNonAlphabeticalSymbol(string word)
        {
            // Define a regular expression pattern to match any non-alphabetical symbol
            string pattern = @"[^a-zA-Zа-яА-Я]";
            Match match = Regex.Match(word, pattern);

            if (match.Success)
            {
                return match.Index;
            }
            else
            {
                return -1; // Return -1 if no non-alphabetical symbol is found
            }
        }
    }
}
