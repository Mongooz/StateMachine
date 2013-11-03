﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine.Library
{
    /// <summary>
    /// Allows chaining of state transition rules
    /// </summary>
    /// <typeparam name="T">The type used to represent state</typeparam>
    public interface IStateMachineOnTransition<T> : IStateMachineSetup<T>
    {
        /// <summary>
        /// Perform an additional operation on transition
        /// </summary>
        /// <param name="transitionAction">The operation to be performed on transition</param>
        /// <returns>The IStateMachineOnTransition to allow further chaining of rules</returns>
        IStateMachineOnTransition<T> Then(TransitionDelegate transitionAction);
    }
}