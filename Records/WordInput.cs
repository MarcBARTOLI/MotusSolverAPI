namespace MotusSolverAPI.Records;

public record WordInput(
    int Length,
    List<char> GuessedLetters,
    List<char> WrongLetters,
    Dictionary<int, char> PlacedLetters
);