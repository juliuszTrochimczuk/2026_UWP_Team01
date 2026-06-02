using System;
using System.Collections.Generic;
using UnityEngine;

namespace Abstraction
{
    public class BaseStateMachine<TOwner, TKey>
        where TOwner : MonoBehaviour
        where TKey : Enum
    {
        private Dictionary<TKey, BaseState<TOwner>> states = new();

        public TKey ActiveState { get; private set; }

        public BaseStateMachine(Dictionary<TKey, BaseState<TOwner>> states, TKey startState)
        {
            this.states = states;
            ActiveState = startState;
        }

        public void OnStart() => states[ActiveState].OnStart();

        public void OnUpdate() => states[ActiveState].OnUpdate();

        public void OnEnd() => states[ActiveState].OnEnd();

        public bool TryChangeState(TKey newStateId)
        {
            if (!states.ContainsKey(newStateId))
                throw new ArgumentException($"State Machine dosen't have registered state under key: {newStateId}");

            if (!states[newStateId].StateCondtions())
                return false;

            states[ActiveState].OnEnd();
            ActiveState = newStateId;
            states[ActiveState].OnStart();
            return true;
        }
    }
}