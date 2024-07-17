namespace TRZ_Console.Services
{
    public static class NameService
    {
        static readonly string[] Keywords = ["във", "в", "от", "на", "дата", "магазин"];
        public static string CleanName(string name)
        {
            List<string> words = name.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            /*List<string> wordsList = [];

            for (int i = 0; i < words.Length; i++)
            {
                if (i == 3)
                    break;

                wordsList.Add(words[i]);
            }

            string lastName = wordsList[^1];
            int symbolIndex = FindFirstNonAlphabeticalSymbol(lastName);

            if (symbolIndex != -1)
            {
                lastName = lastName.Substring(0, symbolIndex);
                wordsList[^1] = lastName;
            }

            name = string.Join(' ', wordsList).TrimEnd();
            List<string> names = name.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            if (names.Count == 3)
            {
                int secondNameSymbolIndex = FindFirstNonAlphabeticalSymbol(names[1]);

                if (secondNameSymbolIndex != -1)
                {
                    name = names[0] + " " + names[2];
                }
            }*/

            ThreeWordFilter(words);
            LastWordFilter(words);
            SecondWordFilter(words);
            KeyWordFilter(words);

            return string.Join(' ', words);
        }

        static void ThreeWordFilter(List<string> words)
        {
            if (words.Count > 3)
                words.RemoveRange(3, words.Count - 3);
        }

        static void LastWordFilter(List<string> words)
        {
            int symbolIndex = FindFirstNonAlphabeticalSymbol(words[^1]);
            if (symbolIndex != -1)
            {
                if (symbolIndex == 0)
                {
                    words.RemoveAt(words.Count - 1);
                    LastWordFilter(words);
                }
                else
                    words[^1] = words[^1].Substring(0, symbolIndex);
            }
        }

        static void SecondWordFilter(List<string> words)
        {
            if (words.Count > 2)
            {
                int symbolIndex = FindFirstNonAlphabeticalSymbol(words[1]);

                if (symbolIndex != -1)
                {
                    if (words[1].Length > 4)
                        words[1] = words[1].Substring(0, symbolIndex);
                    else
                        words.RemoveAt(1);
                }
            }
        }

        static void KeyWordFilter(List<string> words)
        {
            words.RemoveAll(x => Keywords.Any(y => string.Equals(x, y, StringComparison.OrdinalIgnoreCase)));
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
