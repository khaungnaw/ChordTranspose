using System.Text;

class Program
{
    // available keys family
    public static Dictionary<string, int> keys = new Dictionary<string, int>() { { "A", 0 }, { "Bb", 1 }, { "B", 2 }, { "C", 3 }, { "Db", 4 }, { "D", 5 }, {"Eb", 6}, { "E", 7 }, {"F",8}, {"Gb",9}, {"G",10}, {"Ab",11} };
    static void Main()
    {
        Console.WriteLine("Input Current Key: example (C)");
        string input_current_key = Console.ReadLine().ToString();
        if (!keys.ContainsKey(input_current_key))
        {
            Console.WriteLine("Invalid Current Key.");
        }

        Console.WriteLine("Input Current Chord By Comma Separator: example (C,Am,F,Bb,G7,Gbm)");
        string input_current_chords = Console.ReadLine().ToString();

        Console.WriteLine("Input Transposed Key: example (D)");
        string input_expected_transposed_key = Console.ReadLine().ToString();

        if (!keys.ContainsKey(input_expected_transposed_key))
        {
            Console.WriteLine("Invalid Expected Output Key.");
        }

        string[] input_chords = input_current_chords.Split(",");
        int input_current_key_index = keys[input_current_key];
        int input_expected_transposed_key_index = keys[input_expected_transposed_key];
        int key_gap = input_expected_transposed_key_index - input_current_key_index;

        string transformedNotes = Transform(input_chords, key_gap);
        Console.WriteLine($"Transposed Chords : {transformedNotes}");
    }

    static string Transform(string[] input_chords, int key_gap)
    {
        StringBuilder s = new StringBuilder();
        for (int i = 0; i < input_chords.Length; i++)
        {
            (string?, string?) splittedInputValue = SplitStringIntoParts(input_chords[i]);
            string transposedNotes = string.Empty;
            if(splittedInputValue.Item1 != null) {
                int currentNoteKeyIndex = keys[splittedInputValue.Item1]; // find
                int transposedIndex = currentNoteKeyIndex + key_gap;
                if (transposedIndex > (keys.Count - 1))
                {
                    transposedIndex = transposedIndex - keys.Count;
                }
                else if (transposedIndex < 0)
                {
                    transposedIndex = keys.Count + transposedIndex;
                }
                transposedNotes = keys.FirstOrDefault(x => x.Value == transposedIndex).Key;
            } else{
                transposedNotes = input_chords[i]; // if invalid input, return as it is
            }
            
            s.Append($"{transposedNotes}{splittedInputValue.Item2}");
            s.Append(",");
        }

        return s.ToString();
    }
    static (string?, string?) SplitStringIntoParts(string searchValue)
    {
        if (keys.ContainsKey(searchValue))
        {
            return (searchValue, null);
        }
        else if (searchValue.Length > 1) // skip invalid values such as x, y, z
        {
            string firstTwoWords = searchValue.Substring(0, 1);
            string firstOneWord = searchValue.Substring(0, 0);
            if (keys.ContainsKey(firstTwoWords))
            {
                string keySignature = searchValue.Replace(firstTwoWords, "");
                return (firstTwoWords, keySignature);
            }
            else if (keys.ContainsKey(firstOneWord))
            {
                string keySignature = searchValue.Replace(firstOneWord, "");
                return (firstOneWord, keySignature);
            }
        }

        return (null, null);
    }
}
