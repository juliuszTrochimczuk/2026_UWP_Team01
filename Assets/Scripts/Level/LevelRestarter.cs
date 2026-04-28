using Managers;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Level {
    public class LevelRestarter : MonoBehaviour
    {
        private void Start() => InputHandler.Instance.InputActions.Player.ResetGame.performed += RestartGame;

        private void OnDestroy()  => InputHandler.Instance.InputActions.Player.ResetGame.performed -= RestartGame;

        private void RestartGame(InputAction.CallbackContext ctx)
        {
            if (!ctx.performed)
                return;

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}