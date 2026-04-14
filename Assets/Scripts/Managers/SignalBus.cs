using Abstraction;
using AYellowpaper.SerializedCollections;
using UnityEngine;
using UnityEngine.Events;

namespace Managers 
{
    public class SignalBus : PersistentSingleton<SignalBus>
    {
        [SerializeField] private SerializedDictionary<string, UnityEvent> signals;

        protected override SignalBus CreateInstance() => this;

        public void FireSignal(string signalName) => GetSignal(signalName)?.Invoke();
        public void SubscribeEvent(string signalName, UnityAction action) => GetSignal(signalName)?.AddListener(action);
        public void UnsubscribeEvent(string signalName, UnityAction action) => GetSignal(signalName)?.RemoveListener(action);
        public void ClearSignal(string signalName) => GetSignal(signalName)?.RemoveAllListeners();

        public void CreateNewSignal(string signalName) 
        {
            if (signals.ContainsKey(signalName)) 
            {
                Debug.LogError($"There is already signal named {signalName}");
                return;
            }
            signals.Add(signalName, new());
        }


        private UnityEvent GetSignal(string signalName) 
        {
            if (!signals.ContainsKey(signalName))
            {
                Debug.LogError($"There is no any signal named {signalName}, create it in inspector or by using appriopriate method");
                return null;
            }
            return signals[signalName];
        }
    }
}