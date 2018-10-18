namespace StateMachine.Library
{
    /// <summary>
    /// Allows valid state transitions to be specified
    /// </summary>
    /// <typeparam name="T">The type used to represent state</typeparam>
    public interface IStateMachineWhen<T> : IStateMachineSetup<T>
    {
        /// <summary>
        /// Specify a valid transition state after the specified allowed state
        /// </summary>
        /// <param name="transitionState">The allowed proceeding state</param>
        /// <returns>A IStateMachineAllow allowing transition operations to be specified</returns>
        IStateMachineAllow<T> Allow(T transitionState);
    }
}
