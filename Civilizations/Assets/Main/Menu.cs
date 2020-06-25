using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public Image Close1;
    public Image Close2;
    public Vector2 CloseTowards1;
    public Vector2 CloseTowards2;
    public float CloseTime;

    public AudioSource Track;

    public AudioMixer AudioMixer;

    public GameObject MainMenu;
    public GameObject Settings1;
    public GameObject Controls;


    void Start()
    {


        



    }


    void FixedUpdate()
    {
        


    }


    public void Play()
    {

        PlayerPrefs.SetInt("Load", 0);
        Track.Stop();
        Close1.rectTransform.DOMoveX(CloseTowards1.x, CloseTime);
        Close2.rectTransform.DOMoveX(CloseTowards2.x, CloseTime);
        Invoke("Change", CloseTime + 1);

    }


    public void Change()
    {

        SceneManager.LoadScene(2);
    }

    public void Settings()
    {

        MainMenu.SetActive(false);
        Settings1.SetActive(true);
    }

    public void SetVolume(float volume)
    {

        AudioMixer.SetFloat("Volume", volume);

    }

    public void Back()
    {

        Settings1.SetActive(false);
        MainMenu.SetActive(true);

    }

    public void ControlBack()
    {


        Controls.SetActive(false);
        MainMenu.SetActive(true);


    }

    public void Control()
    {
        MainMenu.SetActive(false);
        Controls.SetActive(true);
    }

    public void Quit()
    {

        Application.Quit();

    }
}
