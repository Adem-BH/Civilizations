using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Egypt : MonoBehaviour
{
    public GameObject EgyptLoading;
    public AudioSource EgyptSoundTrack;
    public AudioSource Obby;

    public GameObject Minimap;

    public Camera Main;
  
    void Start()
    {
        


    }


    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            EgyptLoading.SetActive(true);
            Obby.Stop();
            EgyptSoundTrack.Play();
            Minimap.SetActive(false);

        }
    }

    public void Cancel()
    {

        Obby.Play();
        EgyptSoundTrack.Stop();
        EgyptLoading.SetActive(false);
        Minimap.SetActive(true);
    }

    public void StartMission()
    {
        PlayerPrefs.SetInt("Load", 3);
        SceneManager.LoadScene(2);


    }


}
