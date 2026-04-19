using Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI 
{
    [RequireComponent(typeof(Slider))]
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider bar;

        public void UpdateHealthBar(float fillPercentage)
        {
            bar.value = fillPercentage;
        }
    }
}