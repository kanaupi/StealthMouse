using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1.0f;
    public float displayImageDuration = 1f;
    public CanvasGroup clearBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;

    float timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void IsCaught()
    {
        EndLevel(caughtBackgroundImageCanvasGroup);
    }
    public void IsClear()
    {
        EndLevel(clearBackgroundImageCanvasGroup);
    }

    void EndLevel(CanvasGroup imageCanvasGroup)
    {

        timer += Time.deltaTime;

        imageCanvasGroup.alpha = timer / fadeDuration;

        if (timer > fadeDuration + displayImageDuration)
        {
            SceneManager.LoadScene(0);

        }
    }
}
