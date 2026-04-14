using UnityEngine;

namespace UI 
{
    [RequireComponent(typeof(Canvas))]
    public class WorldCanvasCameraHandler : MonoBehaviour
    {
        private void Awake() =>
            GetComponent<Canvas>().worldCamera = Camera.main;

        private void LateUpdate() =>
            gameObject.transform.LookAt(gameObject.transform.position + Camera.main.transform.forward);
    }
}