using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine.Library
{
    /// <summary>
    /// The delegate for transition operations
    /// </summary>
    public delegate void TransitionDelegate();
    
    /// <summary>
    /// Represents a rule for a transition to a new state
    /// </summary>
    /// <typeparam name="T">The type used to represent state</typeparam>
    public class Transition<T> : IStateMachineAllow<T>, IStateMachineOnTransition<T>
    {
        private event TransitionDelegate onTransition;

        /// <summary>
        /// The destination state of this transition
        /// </summary>
        public T State { get; private set; }

        /// <summary>
        /// The logical parent of this transition rule, used internally for rule chaining
        /// </summary>
        private State<T> Parent { get; set; }

        /// <summary>
        /// Create a new instance of Transition to the specified state
        /// </summary>
        /// <param name="parent">The State holding the initial state of this transition</param>
        /// <param name="state">The destination state of this transition</param>
        public Transition(State<T> parent, T state)
        {
            Parent = parent;
            State = state;
        }

        /// <summary>
        /// Allows an operation to be invoked on transition
        /// </summary>
        /// <param name="transitionAction">The operation to be invoked on transition</param>
        /// <returns>A IStateMachineOnTransition to allow for further transitions</returns>
        public IStateMachineOnTransition<T> OnTransition(TransitionDelegate transitionAction)
        {
            onTransition += transitionAction;
            return this;
        }

        /// <summary>
        /// Executes the specified transition operations
        /// </summary>
        public void Execute()
        {
            if (onTransition != null)
            {
                onTransition();
            }
        }

        /// <summary>
        /// Specify additional IStateMachineOnTransition operations to execute on transition
        /// </summary>
        /// <param name="transitionAction">The operation to be invoked on transition</param>
        /// <returns>A IStateMachineOnTransition to allow for further transitions</returns>
        public IStateMachineOnTransition<T> Then(TransitionDelegate transitionAction)
        {
            return OnTransition(transitionAction);
        }

        /// <summary>
        /// Specify additional rules for transition states
        /// </summary>
        /// <param name="transitionState">The state to allow to proceed the TransitionState</param>
        /// <returns>A IStateMachineAllow allowing transition operations to be specified</returns>
        public IStateMachineAllow<T> Allow(T transitionState)
        {
            return Parent.Allow(transitionState);
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
