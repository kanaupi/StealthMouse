using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //以下、ボタンクリック時のシーン遷移
    public void GameStart()
    {
        SceneManager.LoadScene("Main");
    }
    public void Information()
    {
        SceneManager.LoadScene("Information");
    }
    public void Title()
    {
        SceneManager.LoadScene("Title");
    }
    
}
