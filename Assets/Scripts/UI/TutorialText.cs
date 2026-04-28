using UnityEngine;

namespace UI 
{
    public class TutorialText : MonoBehaviour
    {
        private static bool isTutorialCompleted = false;

        private void Start()
        {
            if (!isTutorialCompleted)
            {
                foreach (Node node in NodeHolder.Instance)
                    node.OnNodeClickedAddListener((ctx) => CompleteTutorial());
            }
            else
                gameObject.SetActive(false);
        }

        private void CompleteTutorial()
        {
            isTutorialCompleted = true;
            gameObject.SetActive(false);
        }
    }
}