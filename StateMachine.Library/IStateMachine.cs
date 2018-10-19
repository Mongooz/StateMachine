using System.Collections.Generic;

namespace StateMachine.Library
{
    /// <summary>
    /// An interface for a StateMachine
    /// </summary>
    /// <typeparam name="T">The type used to represent state</typeparam>
    public interface IStateMachine<T>
    {
        /// <summary>
        /// Returns the current state
        /// </summary>
        T CurrentState { get; }

        /// <summary>
        /// Returns a setup class to allow transition rule definitions
        /// </summary>
        /// <returns>A IStateMachineSetup used to specify transition rules</returns>
        IStateMachineSetup<T> Setup();

        /// <summary>
        /// Attempts to transition to the requested state
        /// </summary>
        /// <param name="newState">The state to transition to</param>
        /// <returns>True if the transition is valid and was successful, otherwise false</returns>
        bool TryTransition(T newState);

        /// <summary>
        /// Determines whether the transition to the requested state is valid
        /// </summary>
        /// <param name="newState">The destination of the transition to check</param>
        /// <returns>True if the transition is valid, otherwise false</returns>
        bool IsValidTransition(T newState);

        /// <summary>
        /// Returns the transitions that are valid from the currenst state
        /// </summary>
        /// <returns>Collection of valid transitions from the currenst state</returns>
        IEnumerable<T> GetValidTransitions();
    }
}
