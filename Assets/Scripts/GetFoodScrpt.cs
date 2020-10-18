using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetFoodScrpt : MonoBehaviour
{
    public Text scoreText;
    public static int score;
    public GameObject Click;
    AudioSource audiosource;
    //アイテムに近づいた時に表示するテキストが入ったgameObject
    public GameObject CheeseText;

    bool oneTimeCalled=true;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        audiosource = Click.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //アイテムをGetしてスコアUP、アイテムはDestroy
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            
            if (Input.GetKeyDown(KeyCode.F)&&oneTimeCalled)
            {
                oneTimeCalled = false;
                CheeseText.gameObject.SetActive(false);
                Destroy(other.gameObject);
                audiosource.Play();
                score++;
                scoreText.text = "Score：" + score.ToString()+"/25";
                Debug.Log(score);
            }
        }
    }
    //アイテムの範囲内に入るとFを押してアイテムをGetできるようになる
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            CheeseText.gameObject.SetActive(true);
            oneTimeCalled = true;
        }
    }
    //アイテムの範囲外に出るとポップアップテキストを表示しない
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            CheeseText.gameObject.SetActive(false);
        }
    }
}
