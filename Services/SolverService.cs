using MotusSolverAPI.Records;

namespace MotusSolverAPI.Services;

public class SolverService : ISolverService
{
    private readonly IEnumerable<string> _dic;
    private readonly IDictionary<char, double> _probabilitiesByLetter;

    public SolverService(IRessourceLoader ressourceLoader)
    {
        _dic = ressourceLoader.LoadWordDictionary();
        _probabilitiesByLetter = ressourceLoader.LoadProbabilitiesByLetter();
    }

    public char GetHint(WordInput input)
    {
        var mostProbableSolution = GetPredictions(input).MostProbableSolution();

        var lettersNotFound = mostProbableSolution.LettersNotFound(input).ToList();

        var random = new Random().Next(lettersNotFound.Count);

        return lettersNotFound[random];
    }

    public List<Prediction> GetPredictions(WordInput input)
    {
        var solutions = _dic.WordsThatMatch(input)
                            .Select(word => new { Word = word, Weight = ComputeWeight(word) })
                            .ToList();

        var normalizedRatio = 100 / solutions.Sum(x => x.Weight);

        return solutions.Select(x => new Prediction(x.Word, Math.Round(x.Weight * normalizedRatio))).ToList();
    }

    private double ComputeWeight(string word)
    {
        return word.Sum(letter => _probabilitiesByLetter[letter]);
    }
}