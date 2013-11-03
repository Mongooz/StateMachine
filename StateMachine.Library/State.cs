using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine.Library
{
    /// <summary>
    /// Represents rules for a state of type T with zero or more valid transitions
    /// </summary>
    /// <typeparam name="T">The type used to represent state</typeparam>
    public class State<T> : IStateMachineWhen<T>
    {
        /// <summary>
        /// The state which may be transitioned from
        /// </summary>
        public T TransitionState { get; private set; }

        /// <summary>
        /// The list of valid transitions
        /// </summary>
        public IList<Transition<T>> Transitions { get; private set; }

        /// <summary>
        /// The parent setup instance, used to allow rule chaining
        /// </summary>
        private IStateMachineSetup<T> Parent { get; set; }

        /// <summary>
        /// Create a new instance of State
        /// </summary>
        /// <param name="parent">The IStateMachineSetup containing this State</param>
        /// <param name="state">The initial state for this rule</param>
        public State(IStateMachineSetup<T> parent, T state)
        {
            Parent = parent;
            Transitions = new List<Transition<T>>();
            TransitionState = state;
        }

        /// <summary>
        /// Allow proceeding state from the TransitionState
        /// </summary>
        /// <param name="transitionState">The state to allow to proceed the TransitionState</param>
        /// <returns>A IStateMachineAllow allowing transition operations to be specified</returns>
        public IStateMachineAllow<T> Allow(T transitionState)
        {
            return Transitions.AddIfNotPresent(transition => transition.State, new Transition<T>(this, transitionState));
        }

        /// <summary>
        /// Specify the starting state for a new state machine rule
        /// </summary>
        /// <param name="state">The state which may be transitioned from</param>
        /// <returns>A IStateMachineWhen to allow a transition rule to be specified</returns>
        public IStateMachineWhen<T> When(T state)
        {
            return Parent.When(state);
        }
    }
}
