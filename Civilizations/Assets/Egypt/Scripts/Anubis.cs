using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Anubis : MonoBehaviour
{

    public AudioSource AnubisVoice;
    public AudioSource AnubisVoice2;
    public GameObject Player;
    public GameObject AnubisCanvas;
    public TextMeshProUGUI FirstText;
    public GameObject SecondText;
    public GameObject FirstSpeech;
    public GameObject SecondSpeech;
    public GameObject Spawner;
    public GameObject[] Mummies;
    public bool Done2 = false;

    public GameObject Ground;
    public Camera MainCamera;
    public GameObject DownBoss;

    public GameObject DarknessLoading;
    public bool CheckPoint = false;


    
    IEnumerator StopShaking()
    {

      
         yield return new WaitForSeconds(3.5f);

        DarknessLoading.SetActive(true);

        yield return new WaitForSeconds(3.5f);

        DarknessLoading.GetComponent<Animator>().SetBool("Disappear", true);
        MainCamera.GetComponent<Shake>().AbleToShake = false;
        DownBoss.SetActive(true);

        yield return new WaitForSeconds(3.5f);

        DarknessLoading.SetActive(false);
        CheckPoint = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Detector")
        {

            Destroy(collision.gameObject);
            AnubisCanvas.SetActive(true);
            AnubisVoice.Play();
            Invoke("FadeOut", 4.5f);
           
            Invoke("Done", 17);
           


}
    }


    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        Mummies = GameObject.FindGameObjectsWithTag("Mummies");

        if (Mummies.Length == 0)
        {

            if (Player.GetComponent<Player1>().MummiesKilled >= 30)
            {
               if (Done2 == false)
               {
                Done2 = true;
                AnubisCanvas.SetActive(true);
                SecondSpeech.SetActive(true);
                AnubisVoice2.Play();

                    Invoke("Fall", 7);

                }

            }
        }

    }

    void FadeOut()
    {

        FirstText.GetComponent<Animator>().SetBool("Fade Out", true);
        SecondText.SetActive(true);

    }

    void Done()
    {
        FirstSpeech.SetActive(false);
        AnubisCanvas.SetActive(false);
        Spawner.SetActive(true);

    }

    void Fall()
    {
        Ground.GetComponent<Animator>().SetBool("Fall", true);
        MainCamera.GetComponent<Shake>().ShakeAmmount = 20;
        MainCamera.GetComponent<Shake>().AbleToShake = true;
        AnubisCanvas.SetActive(false);
        StartCoroutine(StopShaking());
    }

   
}
