using MotusSolverAPI.Records;

namespace MotusSolverAPI.Services;

public interface ISolverService
{
    char GetHint(WordInput input);
    List<Prediction> GetPredictions(WordInput input);
}