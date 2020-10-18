using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSoundScript : MonoBehaviour
{
    public GameObject titleSound;
    AudioSource titleAudioSource;
    static bool calledOnce=true;
    GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        if (calledOnce)
        {
            obj = Instantiate(titleSound, transform.position, Quaternion.identity)as GameObject;
            titleAudioSource = titleSound.GetComponent<AudioSource>();
            titleAudioSource.Play();
            DontDestroyOnLoad(this);
            DontDestroyOnLoad(obj.gameObject);
            calledOnce = false;
        }

       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            Destroy(obj);
            Destroy(this.gameObject);
        }
    }
    
}
