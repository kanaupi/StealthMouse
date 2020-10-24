using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject click;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = click.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //以下、ボタンクリック時のシーン遷移
    public void GameStart()
    {
        audioSource.Play();
        SceneManager.LoadScene("Main");
        
    }
    public void Information()
    {
        audioSource.Play();
        SceneManager.LoadScene("Information");
    }
    public void Title()
    {
        audioSource.Play();
        SceneManager.LoadScene("Title");
    }
    
}
