using System.Collections.Generic;
using System.Linq;

namespace StateMachine.Library
{
    /// <summary>
    /// A simple StateMachine implementation
    /// </summary>
    /// <typeparam name="T">The type used to represent state</typeparam>
    public class StateMachine<T> : IStateMachine<T>, IStateMachineSetup<T>
    {
        /// <summary>
        /// The current state of the state machine
        /// </summary>
        public T CurrentState { get; private set; }

        /// <summary>
        /// The list of transition rules
        /// </summary>
        public IList<State<T>> Transitions { get; private set; }

        /// <summary>
        /// Create a new instance of StateMachine with the specified default state
        /// </summary>
        /// <param name="defaultState">Sets the intial state for the state machine</param>
        public StateMachine(T defaultState)
        {
            Transitions = new List<State<T>>();
            CurrentState = defaultState;
        }

        /// <summary>
        /// Returns a setup class to allow transition rule definitions
        /// </summary>
        /// <returns>A IStateMachineSetup used to specify transition rules</returns>
        public IStateMachineSetup<T> Setup()
        {
            return this;
        }

        /// <summary>
        /// Specify the starting state for a new state machine rule
        /// </summary>
        /// <param name="state">The state which may be transitioned from</param>
        /// <returns>A IStateMachineWhen to allow a transition rule to be specified</returns>
        public IStateMachineWhen<T> When(T state)
        {
            return Transitions.AddIfNotPresent(transition => transition.TransitionState, new State<T>(this, state));
        }

        /// <summary>
        /// Attempts to transition to the requested state
        /// </summary>
        /// <param name="newState">The state to transition to</param>
        /// <returns>True if the transition is valid and was successful, otherwise false</returns>
        public bool TryTransition(T newState)
        {
            var transition = GetTransitionTo(newState);
            if (transition != null)
            {
                CurrentState = newState;
                transition.Execute();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines whether the transition to the requested state is valid
        /// </summary>
        /// <param name="newState">The destination of the transition to check</param>
        /// <returns>True if the transition is valid, otherwise false</returns>
        public bool IsValidTransition(T newState)
        {
            if (GetTransitionTo(newState) != null)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<T> GetValidTransitions()
        {
            return Transitions.Where(transition => transition.TransitionState.Equals(CurrentState)).SelectMany(transition => transition.Transitions.Select(transitionTo => transitionTo.State));
        }

        private Transition<T> GetTransitionTo(T newState)
        {
            return GetAvailableTransitions().SingleOrDefault(state => state.State.Equals(newState));
        }

        private IEnumerable<Transition<T>> GetAvailableTransitions()
        {
            return Transitions.Where(transition => transition.TransitionState.Equals(CurrentState)).SelectMany(transition => transition.Transitions);
        }


    }
}
