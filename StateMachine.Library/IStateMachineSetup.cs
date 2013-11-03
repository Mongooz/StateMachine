using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine.Library
{
    /// <summary>
    /// Allows setup of rules for the state machine
    /// </summary>
    /// <typeparam name="T">The type used to represent state</typeparam>
    public interface IStateMachineSetup<T>
    {
        /// <summary>
        /// Specify the starting state for a new state machine rule
        /// </summary>
        /// <param name="state">The state which may be transitioned from</param>
        /// <returns>A IStateMachineWhen to allow a transition rule to be specified</returns>
        IStateMachineWhen<T> When(T state);
    }
}
