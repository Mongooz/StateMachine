using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine.Library
{
    /// <summary>
    /// Interface for functions to be performed on allowed state transitions
    /// </summary>
    /// <typeparam name="T">The type used to represent state</typeparam>
    public interface IStateMachineAllow<T> : IStateMachineWhen<T>
    {
        /// <summary>
        /// Allows an operation to be called upon state transition
        /// </summary>
        /// <param name="transitionAction">The operation to be performed on transition</param>
        /// <returns>A IStateMachineOnTransition which can be used to chain further rules</returns>
        IStateMachineOnTransition<T> OnTransition(TransitionDelegate transitionAction);
    }
}
