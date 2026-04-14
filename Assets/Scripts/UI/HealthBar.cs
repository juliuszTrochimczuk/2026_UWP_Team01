using Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace UI 
{
    [RequireComponent(typeof(Slider))]
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private BaseHealth healthComponent;
        [SerializeField] private Slider bar;

        private void Awake() =>
            healthComponent.OnHealthChangeAddListener(
                (caller) => bar.value = (float)caller.CurrentHealth / (float)caller.MaxHealth
            );
    }
}