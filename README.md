StateMachine
============

An example of how you may use this library is to manage valid transitions between finite states represented by an enum. 

I imagine the concept also lends itself to dynamic updates to transition rules.

Taking a finite definition of states to be:
enum States { Locked, Unlocked, Opened }

A state machine may be created using:
IStateMachine<States> stateMachine = new StateMachine<States>(States.Locked);

In its default state, no transitions are permitted. Note that in this context, attempting to transition to the current state is still considered a transition, and must be explicitly allowed.

The setup can be invoked by calling:
stateMachine.Setup()

This will return a IStateMachineSetup<T> which allows you to being specifying rules. For example:
stateMachine.Setup().When(States.Locked).Allow(States.Unlocked).OnTransition(TurnKey).Then(Unlock)
.When(States.Unlocked).Allow(States.Locked).OnTransition(TurnKey).Then(Lock)
.When(States.Unlocked).Allow(States.Opened).OnTransition(Open)
.When(States.Opened).Allow(States.Unlocked).OnTransition(Close);

The syntax for chaining rules is fairly flexible and the choice of implementation should improve readability depending on your own requirements:
stateMachine.Setup().When(States.Unlocked).Allow(States.Locked).Allow(States.Opened);
Is equivalent to:
stateMachine.Setup().When(States.Unlocked).Allow(States.Locked).When(States.Unlocked).Allow(States.Opened);

The transition operations are extensible, in that you may have any number of delegates to be invoked upon transition.
