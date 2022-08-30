using MotusSolverAPI.Records;

namespace MotusSolverAPI.Services;

internal static class StringExtensions
{
    // ReSharper disable once CompareOfFloatsByEqualityOperator
    internal static string MostProbableSolution(this IEnumerable<Prediction> solutions)
    {
        return solutions.MaxBy(s => s.Probability)?.Word ?? string.Empty;
    }

    internal static IEnumerable<char> LettersNotFound(this string word, WordInput input)
    {
        return word.Where((letter, letterIndex) => !input.PlacedLetters.ContainsKey(letterIndex)
                                                   && !input.GuessedLetters.Contains(letter));
    }

    internal static IEnumerable<string> WordsThatMatch(this IEnumerable<string> dic, WordInput input)
    {
        return dic.Where(word => word.Length == input.Length).Where(input.Match);
    }

    private static bool Match(this WordInput input, string word)
    {
        // verify that the word in dic has the correctly placed letters (each letter is verified by index)
        // and verify the word in dic contains all of the correctly guessed letters
        // and verify the word in dic contains none of the wrongly guessed letters
        return input.PlacedLetters.Keys.All(letterIndex => input.PlacedLetters[letterIndex] == word[letterIndex])
               && input.GuessedLetters.All(letter => word.Contains(letter))
               && input.WrongLetters.All(letter => !word.Contains(letter));
    }
}
