using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float displayImageDuration = 3f;
    public CanvasGroup clearBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public GameObject GameOver;
    public GameObject Clear;
    public GameObject MainSound;
    AudioSource GameOverAudio;
    AudioSource ClearAudio;

    float timer;


    // Start is called before the first frame update
    void Start()
    {
        GameOverAudio = GameOver.GetComponent<AudioSource>();
        ClearAudio = Clear.GetComponent<AudioSource>();
    }

    public void IsCaught()
    {
        EndLevel(caughtBackgroundImageCanvasGroup);
        GameOverAudio.Play();

    }
    public void IsClear()
    {
        EndLevel(clearBackgroundImageCanvasGroup);
        ClearAudio.Play();
    }

    void EndLevel(CanvasGroup imageCanvasGroup)
    {
        Destroy(MainSound);

        timer += Time.deltaTime;

        imageCanvasGroup.alpha = 1;

        if (displayImageDuration < timer)
        {
            SceneManager.LoadScene("Result");

        }
    }
}
