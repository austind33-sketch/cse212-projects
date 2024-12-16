public class Translator
{
    private Dictionary<string, string> _words = new();

    /// <summary>
    /// Adds a translation from 'fromWord' to 'toWord'
    /// </summary>
    /// <param name="fromWord">The word to translate from</param>
    /// <param name="toWord">The word to translate to</param>
    public void AddWord(string fromWord, string toWord)
    {
        // Add the word and its translation to the dictionary.
        // If the word already exists, update the translation.
        _words[fromWord] = toWord;
    }

    /// <summary>
    /// Translates the given word into the stored translation
    /// </summary>
    /// <param name="fromWord">The word to translate</param>
    /// <returns>The translated word or "???" if no translation is available</returns>
    public string Translate(string fromWord)
    {
        // Try to get the translation. If it doesn't exist, return "???".
        return _words.TryGetValue(fromWord, out var translation) ? translation : "???";
    }

    public static void Run()
    {
        var englishToGerman = new Translator();
        
        // Add words to the dictionary
        englishToGerman.AddWord("House", "Haus");
        englishToGerman.AddWord("Car", "Auto");
        englishToGerman.AddWord("Plane", "Flugzeug");

        // Test translations
        Console.WriteLine(englishToGerman.Translate("Car")); // Auto
        Console.WriteLine(englishToGerman.Translate("Plane")); // Flugzeug
        Console.WriteLine(englishToGerman.Translate("Train")); // ???
    }
    
}
