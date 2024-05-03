using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public int checkSound;
    public int checkMusic;
    public bool soundOnOf;
    public Text soundTxt;
    public bool musicOnof;
    public Text musicTxt;
    private void Awake()
    {
        instance = this;


    }

    private void Start()
    {
        //sfx
        if (PlayerPrefs.HasKey("Sonud"))
            checkSound = PlayerPrefs.GetInt("Sonud");
        else
            checkSound = 1;
        if (checkSound == 1)
        {
            UiManager.instance.tapSource.enabled = true;
            soundOnOf = true;
            soundTxt.text = "on";
        }
        else
        {
            UiManager.instance.tapSource.enabled = false;
            soundOnOf = false;
            soundTxt.text = "off";
        }
        //music
        if (PlayerPrefs.HasKey("Music"))
            checkSound = PlayerPrefs.GetInt("Music");
        else
            checkMusic = 1;

        if (checkMusic == 1)
        {
            UiManager.instance.GameAudio.enabled = true;
            musicTxt.text = "on";
        }
        else
        {
            UiManager.instance.GameAudio.enabled = false;
            musicTxt.text = "off";
        }
    }
    public void OnSound()
    {
        if (AudioManager.instance.checkSound == 1)
            UiManager.instance.tapSource.PlayOneShot(UiManager.instance.tapClip);
        soundOnOf = !soundOnOf;

        soundTxt.text = "on";
        checkSound = 1;
        PlayerPrefs.SetInt("Sound", checkSound);
        UiManager.instance.tapSource.enabled = true;

    }
    public void OfSound()
    {
        if (AudioManager.instance.checkSound == 1)
            UiManager.instance.tapSource.PlayOneShot(UiManager.instance.tapClip);
        soundOnOf = !soundOnOf;

        soundTxt.text = "off";
        checkSound = 0;
        PlayerPrefs.SetInt("Sound", checkSound);
        UiManager.instance.tapSource.enabled = false;
    }

    public void OnMusic()
    {
        if (AudioManager.instance.checkSound == 1)
            UiManager.instance.tapSource.PlayOneShot(UiManager.instance.tapClip);
        musicOnof = !musicOnof;

        musicTxt.text = "on";
        checkMusic = 1;
        PlayerPrefs.SetInt("Music", checkMusic);
        UiManager.instance.GameAudio.enabled = true;
    }
    public void OfMusic()
    {
        if (AudioManager.instance.checkSound == 1)
            UiManager.instance.tapSource.PlayOneShot(UiManager.instance.tapClip);
        musicOnof = !musicOnof;
        musicTxt.text = "off";
        checkMusic = 0;
        PlayerPrefs.SetInt("Music", checkMusic);
        UiManager.instance.GameAudio.enabled = false;
    }
}
