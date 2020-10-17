using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StateMachine.Library.Tests
{
    [TestClass]
    public class AllowedStateTests
    {
        enum States { Neutral, Happy, Sad, Tired }

        [TestMethod]
        public void TestAnyAllowedStates()
        {
            IStateMachine<States> stateMachine = new StateMachine<States>(States.Neutral);
            stateMachine.Setup()
                .When(States.Neutral).Allow(AllowedState<States>.Any())
                .When(States.Happy).Allow(AllowedState<States>.Any())
                .When(States.Sad).Allow(AllowedState<States>.Any())
                .When(States.Tired).Allow(States.Neutral);

            Assert.IsTrue(stateMachine.TryTransition(States.Neutral));
            Assert.IsTrue(stateMachine.TryTransition(States.Happy));
            Assert.IsTrue(stateMachine.TryTransition(States.Sad));
            Assert.IsTrue(stateMachine.TryTransition(States.Tired));
            Assert.IsFalse(stateMachine.TryTransition(States.Sad));
            Assert.IsFalse(stateMachine.TryTransition(States.Happy));
            Assert.IsFalse(stateMachine.TryTransition(States.Tired));
            Assert.IsTrue(stateMachine.TryTransition(States.Neutral));
        }
    }
}
