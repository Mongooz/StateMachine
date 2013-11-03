using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StateMachine.Library;

namespace StateMachine.Library.Tests
{
    [TestClass]
    public class StateMachineTests
    {
        enum States { Locked, Unlocked, Opened }

        [TestMethod]
        public void TestMethod1()
        {
            IStateMachine<States> stateMachine = new StateMachine<States>(States.Locked);
            stateMachine.Setup()
                .When(States.Locked).Allow(States.Unlocked).OnTransition(TurnKey).Then(Unlock)
                .When(States.Unlocked).Allow(States.Locked).OnTransition(TurnKey).Then(Lock)
                .When(States.Unlocked).Allow(States.Opened).OnTransition(Open)
                .When(States.Opened).Allow(States.Unlocked).OnTransition(Close);

            Assert.IsTrue(stateMachine.TryTransition(States.Unlocked));
            Assert.IsTrue(stateMachine.TryTransition(States.Locked));
            Assert.IsFalse(stateMachine.TryTransition(States.Opened));
            Assert.IsTrue(stateMachine.TryTransition(States.Unlocked));
            Assert.IsTrue(stateMachine.TryTransition(States.Opened));
            Assert.IsFalse(stateMachine.TryTransition(States.Locked));
            Assert.IsTrue(stateMachine.TryTransition(States.Unlocked));
            Assert.IsTrue(stateMachine.TryTransition(States.Locked));
        }

        private void TurnKey()
        {
            Console.WriteLine("Key Turned");
        }

        private void Unlock()
        {
            Console.WriteLine("Unlocked");
        }

        private void Lock()
        {
            Console.WriteLine("Locked");
        }

        private void Open()
        {
            Console.WriteLine("Opened");
        }

        private void Close()
        {
            Console.WriteLine("Closed");
        }
    }
}
