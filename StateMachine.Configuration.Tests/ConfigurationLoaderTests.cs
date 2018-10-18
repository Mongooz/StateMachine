using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StateMachine.Configuration.Tests
{
    [TestClass]
    public class ConfigurationLoaderTests
    {
        [TestMethod]
        public void TestLoad()
        {
            var result = ConfigurationLoader.Load();
            var secondState = ConfigurationLoader.AllStates.Single(item => item.StateId.Equals("SecondStateId"));

            Assert.IsNotNull(result);
            Assert.AreEqual(result.CurrentState.StateId, "DefaultStateId");
            Assert.IsFalse(result.IsValidTransition(result.CurrentState));
            Assert.IsTrue(result.IsValidTransition(secondState));
            Assert.IsTrue(result.TryTransition(secondState));
            Assert.AreEqual(result.CurrentState.StateId, "SecondStateId");
            Assert.IsFalse(result.IsValidTransition(secondState));
        }
    }
}
