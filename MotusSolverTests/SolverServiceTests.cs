using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotusSolverAPI.Records;
using MotusSolverAPI.Services;

namespace MotusSolverTests
{
    [TestClass]
    public class SolverServiceTests
    {
        private static ISolverService _solverService = null!;

        [ClassInitialize]
        public static void Initialize(TestContext _)
        {
            _solverService = new SolverService(new RessourceLoaderForTests());
        }

        [TestMethod]
        [PredictionDataSource]
        public void TestPredictions(WordInput input, List<Prediction> predictions)
        {
            var result = _solverService.GetPredictions(input);

            CollectionAssert.AreEquivalent(result, predictions);
        }

        [TestMethod]
        [HintDataSource]
        public void TestHints(WordInput input, string solution)
        {
            var result = _solverService.GetHint(input);

            Assert.IsTrue(solution.Contains(result));
        }
    }
}