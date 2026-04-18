using System;
using System.Collections.Generic;

namespace Abstraction
{
    public class StateMachine
    {
        private Dictionary<Enum, State> states;

        public KeyValuePair<Enum, State> ActiveState { get; private set; }

        public StateMachine(Dictionary<Enum, State> states, Enum startStateId)
        {
            this.states = states;
            ActiveState = new(startStateId, states[startStateId]);
        }

        public void OnStart() => ActiveState.Value.OnStart();

        public void OnUpdate() => ActiveState.Value.OnUpdate();

        public void OnEnd() => ActiveState.Value.OnEnd();

        public void TryChangeState(Enum newStateId)
        {
            if (!states.ContainsKey(newStateId))
                throw new ArgumentException($"This state {newStateId} is not present in registered states");

            if (!states[newStateId].StateCondition())
                return;

            ActiveState.Value.OnEnd();
            ActiveState = new(newStateId, states[newStateId]);
            ActiveState.Value.OnStart();
        }
    }
}
