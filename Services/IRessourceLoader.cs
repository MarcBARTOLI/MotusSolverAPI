namespace MotusSolverAPI.Services;

public interface IRessourceLoader
{
    IEnumerable<string> LoadWordDictionary();
    IDictionary<char, double> LoadProbabilitiesByLetter();
}