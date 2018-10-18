namespace StateMachine.Configuration.Model
{
    /// <summary>
    /// Represents a generic state
    /// </summary>
    public class State
    {
        /// <summary>
        /// The unique identifer of the state
        /// </summary>
        public readonly string StateId;

        /// <summary>
        /// A descriptive name of this state
        /// </summary>
        public readonly string StateName;

        /// <summary>
        /// Create a new instance of State
        /// </summary>
        /// <param name="stateId">The unique ID of the state</param>
        /// <param name="stateName">The descriptive name of the state</param>
        public State(string stateId, string stateName)
        {
            StateId = stateId;
            StateName = stateName;
        }

        /// <summary>
        /// Determine if this object should be considered equal to the specified object
        /// </summary>
        /// <param name="obj">The object to check for equality</param>
        /// <returns>True if the specified object is a State with the same ID</returns>
        public override bool Equals(object obj)
        {
            State compareState = obj as State;
            return StateId.Equals(compareState.StateId);
        }

        /// <summary>
        /// Returns a hash code based off the StateId
        /// </summary>
        /// <returns>A hash code as an int</returns>
        public override int GetHashCode()
        {
            return StateId.GetHashCode();
        }
    }
}
