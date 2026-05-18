using Managers;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
public class EnemyTutorialText : MonoBehaviour, IPointerDownHandler
{
    private static bool isTutorialCompleted = false;
    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        if (!isTutorialCompleted)
        {
            SignalBus.Instance.SubscribeEvent("DefensePhaseStarted", StartTutorial);
        }
        else
            canvasGroup.alpha = 0;
    }

    private void StartTutorial()
    {
        StartCoroutine(StartTutorialRoutine());
    }

    public IEnumerator StartTutorialRoutine()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
        canvasGroup.alpha = 1;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Time.timeScale = 1;
        isTutorialCompleted = true;
        canvasGroup.alpha = 0;
    }
}
