using System.Text.Json;
using MotusSolverAPI.Services;
using static System.IO.File;

namespace MotusSolverTests;

public class RessourceLoaderForTests : IRessourceLoader
{
    public IEnumerable<string> LoadWordDictionary()
    {
        return ReadAllLines("../../../../dic.txt");
    }

    public IDictionary<char, double> LoadProbabilitiesByLetter()
    {
        return JsonSerializer.Deserialize<IDictionary<char, double>>(ReadAllText("../../../../probabilitiesByLetter.txt"))!;;
    }
}