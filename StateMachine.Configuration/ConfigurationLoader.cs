using StateMachine.Configuration.Model;
using StateMachine.Library;
using System.Collections.Generic;

namespace StateMachine.Configuration
{
    /// <summary>
    /// Loads a state machine definition from config
    /// </summary>
    public static class ConfigurationLoader
    {
        /// <summary>
        /// A list of states populated by the Load() method
        /// </summary>
        public static IList<State> AllStates { get; private set; }

        /// <summary>
        /// Loads the state machine transitions from the configuration file
        /// </summary>
        /// <returns></returns>
        public static IStateMachine<State> Load()
        {
            AllStates = new List<State>();
            StateMachineSection config = StateMachineSection.Instance;
            StateElement defaultState = config.States.GetItemByKey(config.DefaultStateId);

            IStateMachine<State> stateMachine = new StateMachine<State>(AllStates.AddIfNotPresent(item => item.StateId, new State(defaultState.StateId, defaultState.StateName)));
            IStateMachineSetup<State> setup = stateMachine.Setup();
            foreach (StateElement state in config.States)
            {
                IStateMachineWhen<State> when = setup.When(AllStates.AddIfNotPresent(item => item.StateId, new State(state.StateId, state.StateName)));
                foreach (TransitionElement transition in state.Transitions)
                {
                    StateElement transitionState = config.States.GetItemByKey(transition.StateId);
                    when.Allow(AllStates.AddIfNotPresent(item => item.StateId, new State(transitionState.StateId, transitionState.StateName)));
                }
            }
            return stateMachine;
        }
    }
}
