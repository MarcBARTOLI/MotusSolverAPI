using System.Text.Json;
using static System.IO.File;

namespace MotusSolverAPI.Services;

public class RessourceLoader : IRessourceLoader
{
    public IEnumerable<string> LoadWordDictionary()
    {
        return ReadAllLines("dic.txt");
    }

    public IDictionary<char, double> LoadProbabilitiesByLetter()
    {
        return JsonSerializer.Deserialize<IDictionary<char, double>>(ReadAllText("probabilitiesByLetter.txt"))!;;
    }
}