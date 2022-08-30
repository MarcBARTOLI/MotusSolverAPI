using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotusSolverAPI.Records;
using System.Reflection;
using System.Text.Json;
using static System.IO.File;

namespace MotusSolverTests;

public class PredictionDataSource : Attribute, ITestDataSource
{
    private record Data(WordInput Input, List<Prediction> Expected);

    public IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        var datalist = JsonSerializer.Deserialize<IEnumerable<Data>>(ReadAllText("../../../predictionDataSource.json"));

        foreach (var data in datalist!)
        {
            yield return new object[] {data.Input, data.Expected};
        }
    }

    public string GetDisplayName(MethodInfo methodInfo, object[] data)
    {
        if (data == null)
            throw new ArgumentNullException(nameof(data));

        return $"{methodInfo.Name}";
    }
}

public class HintDataSource : Attribute, ITestDataSource
{
    private record Data(WordInput Input, string Expected);

    public IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        var datalist = JsonSerializer.Deserialize<IEnumerable<Data>>(ReadAllText("../../../hintDataSource.json"));

        foreach (var data in datalist!)
        {
            yield return new object[] {data.Input, data.Expected};
        }
    }

    public string GetDisplayName(MethodInfo methodInfo, object[] data)
    {
        if (data == null)
            throw new ArgumentNullException(nameof(data));

        return $"{methodInfo.Name}";
    }
}