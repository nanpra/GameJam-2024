using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;



    private void Awake()
    {
        instance = this;
    }
    public Animator startClip;
    public AudioClip tapClip;
    public AudioSource tapSource;
    public AudioSource GameAudio;
    public GameObject optionPanal;
    bool onofOptions;
    
    private void Start()
    {
       
        StartCoroutine(EndIntro());
    }
    IEnumerator EndIntro()
    {
        yield return new WaitForSeconds(14);
        startClip.Play("IntroClip");
       // GetComponent<VideoPlayer>().enabled = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            startClip.Play("IntroClip");
           
        }
      
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
       Application.Quit();
    }

    public void OptionButton()
    {
        onofOptions = !onofOptions;
        if(onofOptions)
            optionPanal.SetActive(true);
        else
            optionPanal.SetActive(false );
    }

   
} 
